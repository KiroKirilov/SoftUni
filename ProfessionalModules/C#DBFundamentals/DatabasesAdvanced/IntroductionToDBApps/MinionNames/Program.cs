using IntroductionToDBApps;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                connection.Open();
                string villainNameQuery = $"SELECT Name FROM Villains WHERE Id=@id";

                using (SqlCommand villainCommand=new SqlCommand(villainNameQuery, connection))
                {
                    villainCommand.Parameters.AddWithValue("@id",villainId);
                    string villainName = villainCommand.ExecuteScalar().ToString();

                    if (string.IsNullOrWhiteSpace(villainName) || string.IsNullOrEmpty(villainName))
                    {
                        Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                    }
                    else
                    {
                        Console.WriteLine($"Villain: {villainName}");

                        string minionNamesQuery = $"SELECT m.Name AS Minion, m.Age AS Age FROM Villains v LEFT JOIN MinionsVillains mv ON mv.VillainId=v.Id JOIN Minions m ON m.Id=mv.MinionId WHERE v.Id=@id";

                        List<Minion> minions = new List<Minion>();

                        using (SqlCommand minionCommand = new SqlCommand(minionNamesQuery, connection))
                        {
                            minionCommand.Parameters.AddWithValue("@id",villainId);
                            using (SqlDataReader reader = minionCommand.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string minionName = reader["Minion"].ToString();
                                    int minionAge = int.Parse(reader["Age"].ToString());
                                    Minion minion = new Minion(minionName,minionAge);
                                    minions.Add(minion);
                                }
                            }
                        }

                        if (minions.Count==0)
                        {
                            Console.WriteLine("(no minions)");
                        }
                        else
                        {
                            int counter = 1;

                            foreach (var minion in minions.OrderBy(m=>m.MinionName))
                            {
                                Console.WriteLine($"{counter++}. {minion.ToString()}");
                            }
                        }
                    }
                }

                connection.Close();
            }
        }
    }
}
