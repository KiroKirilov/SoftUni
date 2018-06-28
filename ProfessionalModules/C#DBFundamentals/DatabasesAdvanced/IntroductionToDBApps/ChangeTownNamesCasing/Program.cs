using IntroductionToDBApps;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ChangeTownNamesCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                connection.Open();

                string getTownsQuery = @"SELECT t.Name AS Town FROM Countries c JOIN Towns t ON t.CountryCode=c.Id WHERE c.Name=@country AND c.Name<>UPPER(c.Name) COLLATE SQL_Latin1_General_CP1_CS_AS";

                List<string> townNames = new List<string>();

                using (SqlCommand getTownsCommand=new SqlCommand(getTownsQuery,connection))
                {
                    getTownsCommand.Parameters.AddWithValue("@country", country);
                    using (SqlDataReader reader=getTownsCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string currentTown = reader["Town"].ToString();
                            townNames.Add(currentTown);
                        }
                    }
                }

                if (townNames.Count==0)
                {
                    Console.WriteLine("No town names were affected.");
                }
                else
                {
                    string getCountryIdQuery = @"SELECT Id FROM Countries WHERE Name=@name";
                    object countryId = 0;
                    using (SqlCommand getCountryIdCommand=new SqlCommand(getCountryIdQuery,connection))
                    {
                        getCountryIdCommand.Parameters.AddWithValue("@name",country);
                        countryId = getCountryIdCommand.ExecuteScalar();
                    }

                    string updateTownsQuery = @"UPDATE Towns SET Name=UPPER(Name) WHERE CountryCode=@id";
                    List<string> updated = new List<string>();
                    using (SqlCommand updateTownsCommand=new SqlCommand(updateTownsQuery,connection))
                    {
                        updateTownsCommand.Parameters.AddWithValue("@id", countryId);

                        foreach (var town in townNames)
                        {
                            if (town!=town.ToUpper())
                            {
                                updateTownsCommand.ExecuteNonQuery();
                                updated.Add(town.ToUpper());
                            }
                        }
                    }

                    Console.WriteLine($"{updated.Count} town names were affected.");
                    Console.WriteLine($"[{string.Join(", ", updated)}]");
                }

                connection.Close();
            }
        }
    }
}
