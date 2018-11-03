using SIS.Framework.ActionResults;
using SIS.Framework.Attributes.Action;
using SIS.Framework.Attributes.HttpMethod;
using SIS.Framework.Controllers;
using SIS.Framework.Services;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Api;
using SIS.WebServer.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SIS.Framework.Routers
{
    public class ControllerRouter : IHttpHandler
    {
        private readonly IDependencyContainer dependancyContainer;

        public ControllerRouter(IDependencyContainer dependancyContainer)
        {
            this.dependancyContainer = dependancyContainer;
        }

        public IHttpResponse Handle(IHttpRequest request)
        {
            var controllerName = string.Empty;
            var actionName = string.Empty;
            var requestMethod = request.RequestMethod.ToString();
            if (request.Url == "/")
            {
                controllerName = "Home";
                actionName = "Index";
            }
            else
            {
                var requestUrlSplit = request.Url.Split(
                    "/",
                    StringSplitOptions.RemoveEmptyEntries);

                controllerName = requestUrlSplit[0];
                actionName = requestUrlSplit[1];
            }

            var controller = this.GetController(controllerName, request);
           
            var action = this.GetMethod(requestMethod, controller, actionName);
            if (controller == null || action == null)
            {
                throw new NullReferenceException();
            }
            object[] actionParameters = this.MapActionParameters(action, request,controller);

            IActionResult actionResult = this.InvokeAction(controller, action, actionParameters);

            return this.Authorize(controller, action) ?? 
                this.PrepareResponse(actionResult);
        }

        private IActionResult InvokeAction(Controller controller, MethodInfo action, object[] actionParameters)
        {
            return (IActionResult)action.Invoke(controller, actionParameters);
        }

        private object[] MapActionParameters(MethodInfo action, IHttpRequest request, Controller controller)
        {
            ParameterInfo[] actionParametersInfo = action.GetParameters();
            object[] mappedActionParameters = new object[actionParametersInfo.Length];

            for (int index = 0; index < actionParametersInfo.Length; index++)
            {
                ParameterInfo currentParameterInfo = actionParametersInfo[index];

                if (currentParameterInfo.ParameterType.IsPrimitive || currentParameterInfo.ParameterType==typeof(string))
                {
                    mappedActionParameters[index] = ProcessPrimitiveParameter(currentParameterInfo, request);
                }
                else
                {
                    object bindingModel = ProcessBindingModelParameter(currentParameterInfo, request);
                    controller.ModelState.IsValid = this.IsValidModel(bindingModel);
                    mappedActionParameters[index] = bindingModel;
                }
            }

            return mappedActionParameters;
        }

        private bool IsValidModel(object bindingModel)
        {
            var properties = bindingModel.GetType().GetProperties();

            foreach (var property in properties)
            {
                var propertyValidationAttributes = property
                    .GetCustomAttributes()
                    .Where(ca => ca is ValidationAttribute)
                    .Cast<ValidationAttribute>()
                    .ToList();

                foreach (var validationAttribute in propertyValidationAttributes)
                {
                    var propertyValue = property.GetValue(bindingModel);

                    if (!validationAttribute.IsValid(propertyValue))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private object ProcessBindingModelParameter(ParameterInfo param, IHttpRequest request)
        {
            Type bindingModelType = param.ParameterType;
            var bindingModelInstance = Activator.CreateInstance(bindingModelType);
            var bindingModelProps = bindingModelType.GetProperties();

            foreach (var prop in bindingModelProps)
            {
                try
                {
                    object value = this.GetParameterFromRequestData(request, prop.Name);
                    prop.SetValue(bindingModelInstance, Convert.ChangeType(value, prop.PropertyType));
                }
                catch 
                {
                    Console.WriteLine($"Property {prop.Name} could not be mapped");
                }
            }

            return Convert.ChangeType(bindingModelInstance, bindingModelType);
        }

        private object ProcessPrimitiveParameter(ParameterInfo param, IHttpRequest request)
        {
            object value = this.GetParameterFromRequestData(request, param.Name);
            return Convert.ChangeType(value, param.ParameterType);
        }

        private object GetParameterFromRequestData(IHttpRequest request, string paramName)
        {
            if (request.QueryData.ContainsKey(paramName))
            {
                return request.QueryData[paramName];
            }
            if (request.FormData.ContainsKey(paramName))
            {
                return request.FormData[paramName];
            }

            return null;
        }

        private Controller GetController(string controllerName, IHttpRequest request)
        {
            if (controllerName!=null)
            {
                string controllerTypeName = string.Format("{0}.{1}.{2}, {0}",
                    MvcContext.Get.AssemblyName,
                    MvcContext.Get.ControllersFolder,
                    controllerName + MvcContext.Get.ControllersSuffix);

                Type controllerType = Type.GetType(controllerTypeName);
                Controller controller = (Controller)this.dependancyContainer.CreateInstance(controllerType);
                if (controller!=null)
                {
                    controller.Request = request;
                }

                return controller;
            }

            return null;
        }

        private MethodInfo GetMethod(string requestMethod, Controller controller, string actionName)
        {
            MethodInfo method = null;

            foreach (MethodInfo methodInfo in this.GetSuitableMethods(controller,actionName))
            {
                IEnumerable<HttpMethodAttribute> attributes = methodInfo
                    .GetCustomAttributes()
                    .Where(attr => attr is HttpMethodAttribute)
                    .Cast<HttpMethodAttribute>();

                if (!attributes.Any() && requestMethod.ToUpper()=="GET")
                {
                    return methodInfo;
                }

                foreach (HttpMethodAttribute attribute in attributes)
                {
                    if (attribute.IsValid(requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }

            return method;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods(Controller controller, string actionName)
        {
            if (controller==null)
            {
                return new MethodInfo[0];
            }

            return controller
                .GetType()
                .GetMethods()
                .Where(methodInfo => methodInfo.Name.ToLower() == actionName.ToLower());
        }

        private IHttpResponse PrepareResponse(IActionResult actionResult)
        {
            string invocationResult = actionResult.Invoke();

            if (actionResult is IViewable)
            {
                return new HtmlResult(invocationResult, HttpResponseStatusCode.Ok);
            }
            else if (actionResult is IRedirectable)
            {
                return new WebServer.Results.RedirectResult(invocationResult);
            }
            else
            {
                throw new InvalidOperationException("This view result is not supported.");
            }
        }

        private IHttpResponse Authorize(Controller controller, MethodInfo action)
        {
            if (action.GetCustomAttributes()
                .Where(a => a is AuthorizeAttribute)
                .Cast<AuthorizeAttribute>()
                .Any(a => !a.IsAuthrised(controller.Identity)))
            {
                return new UnauthorizedResult();
            }

            return null;
        }
       
    }
}
