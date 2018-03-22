using LoggingApplication.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LoggingApplication.Models
{
    class LogFile : ILogFile
    {
        private const string defaultPath = "./data/";

        public int Size { get; private set; }

        public string Path { get; }

        public LogFile(string fileName)
        {
            this.Path = defaultPath + fileName;
            CreateFile();
            this.Size = 0;
        }

        private void CreateFile()
        {
            Directory.CreateDirectory(defaultPath);
            File.AppendAllText(this.Path, "");
        }

        public void WriteToFile(string errorLog)
        {
            File.AppendAllText(this.Path, errorLog+Environment.NewLine);

            var addedSize = 0;
            for (int i = 0; i < errorLog.Length; i++)
            {
                addedSize += errorLog[i];
            }

            this.Size += addedSize;
        }
    }
}
