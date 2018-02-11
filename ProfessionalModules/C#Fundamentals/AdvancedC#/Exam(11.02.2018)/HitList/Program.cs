using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4
{
    class Program
    {
        static void Main(string[] args)
        {
            var infoIndexForKill = int.Parse(Console.ReadLine());
            var targetData = new Dictionary<string,Dictionary<string,string>>();

            var input = "";

            while ((input=Console.ReadLine())!= "end transmissions")
            {
                var dataArgs = input.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(d=>d.Trim()).ToArray();

                var targetName = dataArgs[0];
                var targetProps = dataArgs[1].Split(new char[] { ':',';'},StringSplitOptions.RemoveEmptyEntries)
                    .Select(d => d.Trim()).ToArray(); ;

                for (int i = 0; i < targetProps.Length; i+=2)
                {
                    var propKey = targetProps[i];
                    var propVal = targetProps[i + 1];

                    if (!targetData.ContainsKey(targetName))
                    {
                        targetData.Add(targetName,new Dictionary<string, string>());
                    }

                    if (!targetData[targetName].ContainsKey(propKey))
                    {
                        targetData[targetName].Add(propKey,propVal);
                    }
                    else
                    {
                        targetData[targetName][propKey] = propVal;
                    }
                }
            }

            var killInput = Console.ReadLine().Split(new char[] { ' '},StringSplitOptions.RemoveEmptyEntries)
                .Select(d=>d.Trim()).ToArray();
            var killTarget = killInput[1];
            long targetIndex = 0;

            Console.WriteLine($"Info on {killTarget}:");

            foreach (var item in targetData[killTarget].OrderBy(d=>d.Key))
            {
                Console.WriteLine($"---{item.Key}: {item.Value}");
                targetIndex += item.Value.Length + item.Key.Length;
            }

            Console.WriteLine($"Info index: {targetIndex}");

            if (targetIndex<infoIndexForKill)
            {
                Console.WriteLine($"Need {infoIndexForKill-targetIndex} more info.");
            }
            else
            {
                Console.WriteLine("Proceed");
            }
        }
    }
}