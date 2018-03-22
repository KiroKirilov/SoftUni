using LoggingApplication.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingApplication.Models
{
    class Logger : ILogger
    {
        private ICollection<IAppender> appenders;

        public Logger(ICollection<IAppender>appenders)
        {
            this.appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders => this.appenders as IReadOnlyCollection<IAppender>;

        public void Log(IError error)
        {
            foreach (var appender in this.appenders)
            {
                if (appender.ErrorLevel<=error.ErrorLevel)
                {
                    appender.Append(error);
                }
            }
        }
    }
}
