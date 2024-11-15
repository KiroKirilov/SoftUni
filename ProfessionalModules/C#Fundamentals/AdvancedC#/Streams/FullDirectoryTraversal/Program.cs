﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace E08_FullDirectoryTraversal
{
    public class FullDirectoryTraversal
    {
        public static void Main()
        {
            string sourcePath = "./";
            string destinationPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filesDict = new Dictionary<string, Dictionary<string, long>>();

            Console.WriteLine($"Searching directory '{sourcePath}' (including sub-directories)");
            SearchDirectory(sourcePath, destinationPath, filesDict);
        }

        private static void SearchDirectory(string sourcePath, string destinationPath, Dictionary<string, Dictionary<string, long>> filesDict)
        {
            var filesInDirectory = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories);
            foreach (var file in filesInDirectory)
            {
                var fileInfo = new FileInfo(file);
                var extension = fileInfo.Extension;
                var name = fileInfo.Name;
                var length = fileInfo.Length;

                if (!filesDict.ContainsKey(extension))
                {
                    filesDict[extension] = new Dictionary<string, long>();
                }
                if (!filesDict[extension].ContainsKey(name))
                {
                    filesDict[extension][name] = length;
                }
            }
            var filesDictSorted = filesDict
                                .OrderByDescending(x => x.Value.Count)  // number of files
                                .ThenBy(x => x.Key);                    // extension name
            // Write Report
            Console.WriteLine($@"Result saved in '{destinationPath}\reportAllDirs.txt'");
            using (var report = new StreamWriter($"{destinationPath}/reportAllDirs.txt"))
            {
                foreach (var kvp in filesDictSorted)
                {
                    var extension = kvp.Key;
                    var files = filesDict[extension].OrderByDescending(x => x.Value); // length

                    report.WriteLine(extension);
                    foreach (var file in files)
                    {
                        report.WriteLine($"--{file.Key} - {(double)file.Value / 1024:f3} kb");
                    }
                }
            }
        }
    }
}