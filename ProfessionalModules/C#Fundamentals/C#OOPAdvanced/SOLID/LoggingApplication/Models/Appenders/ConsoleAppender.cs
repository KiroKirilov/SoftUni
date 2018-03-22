using LoggingApplication.Contracts;
using LoggingApplication.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingApplication.Models.Apeenders
{
    class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, ErrorLevel errorLevel)
        {
            this.Layout = layout;
            this.ErrorLevel = errorLevel;
            this.MessagesAppended = 0;
        }

        public int MessagesAppended { get; private set; }

        public ILayout Layout { get; }

        public ErrorLevel ErrorLevel { get; }

        public void Append(IError error)
        {
            var formatedError = this.Layout.FormatError(error);
            Console.WriteLine(formatedError);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            var output = $"Appender type: ConsoleAppender, Layout type: {this.Layout.GetType().Name}, Report level: {this.ErrorLevel.ToString()}, Messages appended: {this.MessagesAppended}";
            return output;
        }
    }
}
