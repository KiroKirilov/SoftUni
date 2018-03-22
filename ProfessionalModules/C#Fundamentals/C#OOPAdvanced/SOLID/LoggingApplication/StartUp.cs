using LoggingApplication.Contracts;
using LoggingApplication.Controllers;
using LoggingApplication.Enums;
using LoggingApplication.Factories;
using LoggingApplication.Models;
using LoggingApplication.Models.Apeenders;
using LoggingApplication.Models.Errors;
using LoggingApplication.Models.Layouts;
using System;
using System.Collections.Generic;

namespace LoggingApplication
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var logger = CreateLogger();
            var errorFactory = new ErrorFactory();
            var engine = new Engine(logger, errorFactory);
            engine.Run();
        }

        static ILogger CreateLogger()
        {
            var appenders = new List<IAppender>();
            var amountOfAppenders = int.Parse(Console.ReadLine());

            var layoutFactory = new LayoutFactory();
            var appenderFacotry = new AppenderFactory(layoutFactory);

            for (int i = 0; i < amountOfAppenders; i++)
            {
                var dataArgs = Console.ReadLine().Split();
                var appenderType = dataArgs[0];
                var layoutType = dataArgs[1];
                var errorLevel = "INFO";

                if (dataArgs.Length==3)
                {
                    errorLevel = dataArgs[2];
                }

                var appender = appenderFacotry.CreateAppender(appenderType, errorLevel, layoutType);
                appenders.Add(appender);
            }
            var logger= new Logger(appenders);
            return logger;
        }
    }
}
