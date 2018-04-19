using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IWriter
{
    void AppendLine(string message);

    void WriteAllLines();
}

