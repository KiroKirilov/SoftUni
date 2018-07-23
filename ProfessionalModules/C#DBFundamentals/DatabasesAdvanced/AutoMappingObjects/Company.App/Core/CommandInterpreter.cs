using Company.App.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Company.App.Core
{
    class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandSuffix = "Command";

        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        
        public string Read(string[] input)
        {
            string commandName = input[0] + CommandSuffix;

            string[] arguments = input.Skip(1).ToArray();

            var type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == commandName);

            if (type==null)
            {
                throw new ArgumentException(Constants.InvalidCommandMessage);
            }

            var constructor = type.GetConstructors().First();

            var ctorParamTypes = constructor.GetParameters()
                .Select(p=>p.ParameterType);

            var service = ctorParamTypes.Select(serviceProvider.GetService)
                .ToArray();

            var command = (ICommand)constructor.Invoke(service);

            string result = command.Execute(arguments);

            return result;
        }
    }
}
