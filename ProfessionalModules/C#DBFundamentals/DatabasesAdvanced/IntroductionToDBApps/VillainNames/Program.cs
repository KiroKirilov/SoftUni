using IntroductionToDBApps;
using System;
using System.Data.SqlClient;

namespace VillainNames
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                connection.Open();
                string villainsInfoQuery = @"SELECT v.Name AS VillainName, COUNT(mv.MinionId) AS MinionsCount FROM Villains v JOIN MinionsVillains mv ON mv.VillainId=v.Id GROUP BY v.Name HAVING COUNT(mv.MinionId)>3 ORDER BY MinionsCount DESC";

                using (SqlCommand command=new SqlCommand(villainsInfoQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["VillainName"]} - {reader["MinionsCount"]}");
                        }
                    }
                }

                connection.Close();
            }
        }
    }
}