﻿using System;
using System.IO;
using System.Threading.Tasks;

namespace SliceFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string videoPath = Console.ReadLine();
            string destinationPath = Console.ReadLine();
            int parts = int.Parse(Console.ReadLine());

            SliceAsync(videoPath, destinationPath, parts);

            Console.WriteLine("Anything else?");
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                if (input=="exit")
                {
                    break;
                }
            }
        }

        private static void SliceAsync(string sourceFile, string destinationPath, int parts)
        {
            Task.Run(() => Slice(sourceFile, destinationPath, parts));
        }

        private static void Slice(string sourceFile,string destinationPath, int parts)
        {
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            using (FileStream source=new FileStream(sourceFile,FileMode.Open))
            {
                FileInfo fileInfo = new FileInfo(sourceFile);
                long partLength = (source.Length / parts) + 1;
                long currentByte = 0;
                long bufferLength = (source.Length / parts) + 1;

                for (int currentPart = 1; currentPart <=parts; currentPart++)
                {
                    string filePath = $"{destinationPath}/Part-{currentPart}{fileInfo.Extension}";

                    using (FileStream destination=new FileStream(filePath,FileMode.Create))
                    {
                        byte[] buffer = new byte[bufferLength];
                        while (currentByte<=partLength*currentPart)
                        {
                            int readBytesCount = source.Read(buffer, 0, buffer.Length);
                            if (readBytesCount==0)
                            {
                                break;
                            }

                            destination.Write(buffer, 0, readBytesCount);
                            currentByte += readBytesCount;
                        }
                    }
                }
            }

            Console.WriteLine("Slicing done!");
        }
    }
}
