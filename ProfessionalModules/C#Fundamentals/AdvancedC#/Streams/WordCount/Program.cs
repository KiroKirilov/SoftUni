using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace PrintOddLines
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var readText = new StreamReader("text.txt"))
            {
                using (var readWords = new StreamReader("words.txt"))
                {
                    string word;
                    var words = new Queue<string>();
                    while ((word = readWords.ReadLine()) != null)
                    {
                        if (!words.Contains(word))
                        {
                            words.Enqueue(word);
                        }
                    }

                    var allText = readText.ReadToEnd().ToLower();
                    var allWords = Regex.Split(allText,@"\W+");

                    var dict = new Dictionary<string,int>();

                    foreach (var wordFromText in allWords)
                    {
                        if (words.Contains(wordFromText))
                        {
                            if (!dict.ContainsKey(wordFromText))
                            {
                                dict.Add(wordFromText, 1);
                            }
                            else
                            {
                                dict[wordFromText]++;
                            }
                        }
                    }

                    using (var writer=new StreamWriter("result.txt"))
                    {
                        foreach (var item in dict.OrderByDescending(w=>w.Value))
                        {
                            writer.WriteLine($"{item.Key} -> {item.Value}");
                        }
                    }
                }
            }
        }
    }
}