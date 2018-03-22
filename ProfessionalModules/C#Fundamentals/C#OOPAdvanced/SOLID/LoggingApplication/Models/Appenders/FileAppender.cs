using LoggingApplication.Contracts;
using LoggingApplication.Enums;
using LoggingApplication.Models;

namespace LoggingApplication.Appenders
{
    internal class FileAppender : IAppender
    {
        private ILogFile file;

        public FileAppender(ILayout layout, ErrorLevel errorLevel, ILogFile file)
        {
            this.Layout = layout;
            this.ErrorLevel = errorLevel;
            this.file = file;
        }

        public ILayout Layout { get; }

        public ErrorLevel ErrorLevel { get; }

        public int MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            var formattedError = this.Layout.FormatError(error);
            this.file.WriteToFile(formattedError);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            var output = $"Appender type: FileAppender, Layout type: {this.Layout.GetType().Name}, Report level: {this.ErrorLevel}, Messages appended: {this.MessagesAppended}, File size: {this.file.Size}";
            return output;
        }
    }
}