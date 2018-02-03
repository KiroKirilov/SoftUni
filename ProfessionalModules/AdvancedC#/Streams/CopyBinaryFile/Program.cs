using System;
using System.IO;

namespace CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var source=new FileStream("thicc.jpg",FileMode.Open))
            {
                using (var destination=new FileStream("more thicc.jpg",FileMode.Create))
                {
                    var buffer = new byte[4096];
                    while (true)
                    {
                        var readBytes = source.Read(buffer,0,buffer.Length);
                        if (readBytes == 0)
                            break;

                        destination.Write(buffer,0,readBytes);
                    }
                }
            }
        }
    }
}
