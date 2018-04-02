 using System.Linq;

namespace P01_HarvestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var input = "";
            var type = typeof(HarvestingFields);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic| BindingFlags.Static|BindingFlags.Instance);
            while ((input=Console.ReadLine())!="HARVEST")
            {
                List<FieldInfo> fieldsFromQuery = null;
                switch (input)
                {
                    case "private":
                        fieldsFromQuery = fields.Where(f => f.IsPrivate).ToList();
                        break;

                    case "protected":
                        fieldsFromQuery = fields.Where(f => f.IsFamily).ToList();
                        break;

                    case "public":
                        fieldsFromQuery = fields.Where(f => f.IsPublic).ToList();
                        break;

                    case "all":
                        fieldsFromQuery = fields.ToList();
                        break;
                }

                string[] result = fieldsFromQuery.Select(f => $"{f.Attributes.ToString().ToLower()} {f.FieldType.Name} {f.Name}").ToArray();

                Console.WriteLine(string.Join(Environment.NewLine, result).Replace("family", "protected"));
            }
        }
    }
}
