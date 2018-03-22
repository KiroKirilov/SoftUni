using LoggingApplication.Appenders;
using LoggingApplication.Contracts;
using LoggingApplication.Enums;
using LoggingApplication.Models;
using LoggingApplication.Models.Apeenders;
using System;

namespace LoggingApplication.Factories
{
    class AppenderFactory
    {
        private const string defaultFileName= "logfile{0}.txt";
        private LayoutFactory layoutFactory;
        private int amountOfFiles;
        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
            this.amountOfFiles = 0;
        }

        public IAppender CreateAppender(string type, string errorLvl, string layoutType)
        {
            ILayout layout = this.layoutFactory.CreateLayout(layoutType);
            ErrorLevel errorLevel = this.ParseErrorLevel(errorLvl);

            IAppender appender = null;

            switch (type)
            {
                case "ConsoleAppender":
                    appender = new ConsoleAppender(layout,errorLevel);
                    break;

                case "FileAppender":
                    var file = new LogFile(string.Format(defaultFileName,this.amountOfFiles));
                    appender = new FileAppender(layout, errorLevel,file);
                    break;
                default:
                    throw new ArgumentException("Invalid appender.");
            }

            return appender;
        }

        private ErrorLevel ParseErrorLevel(string errorLvl)
        {
            try
            {
                var level = Enum.Parse(typeof(ErrorLevel), errorLvl);
                return (ErrorLevel)level;
            }
            catch (ArgumentException argEx)
            {
                throw new ArgumentException("Invalid error level.",argEx);
            }
        }
    }
}
