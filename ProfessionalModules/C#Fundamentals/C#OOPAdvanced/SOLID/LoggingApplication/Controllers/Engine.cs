using LoggingApplication.Contracts;
using LoggingApplication.Factories;
using LoggingApplication.Models.Errors;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingApplication.Controllers
{
    class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        public Engine(ILogger logger, ErrorFactory errorFactory)
        {
            this.logger = logger;
            this.errorFactory = errorFactory;
        }

        public void Run()
        {
            var input = "";
            while ((input = Console.ReadLine())!="END")
            {
                var args = input.Split("|");
                var date = args[1];
                var msg = args[2];
                var level = args[0];

                var error = this.errorFactory.CreateError(date, level, msg);
                logger.Log(error);
            }

            Console.WriteLine("Logger info:");

            foreach (var appender in this.logger.Appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
