using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

public class Hospital
{
    public static void Main()
    {
        var departments = new Dictionary<string, List<string>>();
        var doctors = new Dictionary<string, List<string>>();

        var input = "";

        while ((input = Console.ReadLine()) != "Output")
        {
            var patientData = input.Split();
            var department = patientData[0];
            var doctor = patientData[1] + " " + patientData[2];
            var patient = patientData[3];

            if (!departments.ContainsKey(department))
                departments.Add(department, new List<string>());

            if (!doctors.ContainsKey(doctor))
                doctors.Add(doctor, new List<string>());

            departments[department].Add(patient);
            doctors[doctor].Add(patient);
        }

        while ((input = Console.ReadLine()) != "End")
        {
            var outputType = input.Split();

            if (outputType.Length == 1)
            {
                foreach (var patient in departments[outputType[0]])
                {
                    Console.WriteLine(patient);
                }
            }
            else
            {
                var roomNumber = 0;

                if (int.TryParse(outputType[1], out roomNumber))
                {
                    var toSkip = 3 * (roomNumber - 1);
                    foreach (var patient in departments[outputType[0]].Skip(toSkip).Take(3).OrderBy(p => p))
                    {
                        Console.WriteLine(patient);
                    }
                }
                else
                {
                    foreach (var patient in doctors[input].OrderBy(p => p))
                    {
                        Console.WriteLine(patient);
                    }
                }
            }
        }
    }
}