using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class CommandInterpreter : ICommandInterpreter
{
    private const string CommandSuffix = "Command";

    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; }

    public IProviderController ProviderController { get; }

    public string ProcessCommand(IList<string> args)
    {
        ICommand command = this.CreateCommand(args);

        return command.Execute();
    }

    private ICommand CreateCommand(IList<string> args)
    {
        string fullCommandName = args[0] + CommandSuffix;
        args.RemoveAt(0);

        Type commandType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == fullCommandName);

        if (commandType==null)
        {
            throw new ArgumentException(string.Format(Constants.CommandNotFound,fullCommandName));
        }

        if (!typeof(ICommand).IsAssignableFrom(commandType))
        {
            throw new InvalidOperationException(string.Format(Constants.CommandNotImplementingICommand, fullCommandName));
        }

        ConstructorInfo constructorInfo = commandType.GetConstructors().First();
        ParameterInfo[] constructorParametersInfo = constructorInfo.GetParameters();
        object[] parametersToInvokeWith = new object[constructorParametersInfo.Length];

        for (int i = 0; i < constructorParametersInfo.Length; i++)
        {
            Type currentParameterType = constructorParametersInfo[i].ParameterType;

            if (currentParameterType== typeof(IList<string>))
            {
                parametersToInvokeWith[i] = args;
                continue;
            }

            PropertyInfo propertyToPass = this.GetType().GetProperties().FirstOrDefault(p=>p.PropertyType==currentParameterType);
            parametersToInvokeWith[i] = propertyToPass.GetValue(this);
        }

        ICommand command = (ICommand)Activator.CreateInstance(commandType, parametersToInvokeWith);

        return command;
    }
}

