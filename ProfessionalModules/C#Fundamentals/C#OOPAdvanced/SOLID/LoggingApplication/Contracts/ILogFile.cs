using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingApplication.Contracts
{
    interface ILogFile
    {
        int Size { get; }

        string Path { get; }

        void WriteToFile(string errorLog);
    }
}
