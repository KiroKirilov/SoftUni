using IntroductionToDBApps;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PrintAllMinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                connection.Open();

                string getAllNamesQuery = "SELECT Name FROM Minions";

                List<string> names = new List<string>();

                using (SqlCommand command=new SqlCommand(getAllNamesQuery,connection))
                {
                    using (SqlDataReader reader=command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string currentName = reader["Name"].ToString();
                            names.Add(currentName);
                        }
                    }
                }
                
                int evenCounter = 0;
                int oddCounter = names.Count-1;

                for (int i = 0; i < names.Count; i++)
                {
                    if (i%2==0)
                    {
                        Console.WriteLine(names[evenCounter]);
                        evenCounter++;
                    }
                    else
                    {
                        Console.WriteLine(names[oddCounter]);
                        oddCounter--;
                    }
                }

                connection.Close();
            }
        }
    }
}
