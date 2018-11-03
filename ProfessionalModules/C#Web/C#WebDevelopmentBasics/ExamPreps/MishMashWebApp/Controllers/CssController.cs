using SIS.HTTP.Enums;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using SIS.WebServer.Results;

namespace MishMashWebApp.Controllers
{
    public class CssController : Controller
    {
        [HttpGet("css/reset-css.css")]
        public IHttpResponse ResetCss()
        {
            var css = System.IO.File.ReadAllText("wwwroot/reset-css.css");
            return new TextResult(css, HttpResponseStatusCode.Ok, "text/css");
        }

        [HttpGet("css/style.css")]
        public IHttpResponse StyleCss()
        {
            var css = System.IO.File.ReadAllText("wwwroot/style.css");
            return new TextResult(css, HttpResponseStatusCode.Ok, "text/css");
        }

        [HttpGet("css/bootstrap.min.css")]
        public IHttpResponse BootstrapCss()
        {
            var css = System.IO.File.ReadAllText("wwwroot/bootstrap.min.css");
            return new TextResult(css, HttpResponseStatusCode.Ok, "text/css");
        }

        [HttpGet("Users/css/reset-css.css")]
        public IHttpResponse UResetCss()
        {
            return this.ResetCss();
        }

        [HttpGet("Users/css/style.css")]
        public IHttpResponse UStyleCss()
        {
            return this.StyleCss();
        }

        [HttpGet("Users/css/bootstrap.min.css")]
        public IHttpResponse UBootstrapCss()
        {
            return this.BootstrapCss();
        }

        [HttpGet("Channel/css/reset-css.css")]
        public IHttpResponse CResetCss()
        {
            return this.ResetCss();
        }   

        [HttpGet("Channel/css/style.css")]
        public IHttpResponse CStyleCss()
        {
            return this.StyleCss();
        }

        [HttpGet("Channel/css/bootstrap.min.css")]
        public IHttpResponse CBootstrapCss()
        {
            return this.BootstrapCss();
        }
    }
}