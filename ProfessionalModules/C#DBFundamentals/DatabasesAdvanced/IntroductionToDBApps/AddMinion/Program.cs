using IntroductionToDBApps;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace AddMinion
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] minionData = Console.ReadLine()
                                         .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                         .Skip(1)
                                         .Select(i => i.Trim())
                                         .ToArray();

            string minionName = minionData[0];
            int minionAge = int.Parse(minionData[1]);
            string townName = minionData[2];

            string villainName = Console.ReadLine()
                                        .Split(':', StringSplitOptions.RemoveEmptyEntries)[1].Trim();

            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                connection.Open();

                string townFindQuery = @"SELECT Id FROM Towns WHERE Name=@name";
                object townId = 0;

                using (SqlCommand townCommand = new SqlCommand(townFindQuery, connection))
                {
                    townCommand.Parameters.AddWithValue("@name", townName);
                    townId = townCommand.ExecuteScalar();

                    if (townId == null)
                    {
                        string insertTownQuery = @"INSERT INTO Towns(Name) VALUES (@town)";
                        using (SqlCommand insertTownCommand = new SqlCommand(insertTownQuery, connection))
                        {
                            insertTownCommand.Parameters.AddWithValue("@town", townName);
                            insertTownCommand.ExecuteNonQuery();
                            townId = townCommand.ExecuteScalar();
                            Console.WriteLine($"Town {townName} was added to the database.");
                        }
                    }

                }

                string villainFindQuery = @"SELECT Id FROM Villains WHERE Name=@name";
                object villainId = 0;

                using (SqlCommand villainFindCommand = new SqlCommand(villainFindQuery, connection))
                {
                    villainFindCommand.Parameters.AddWithValue("@name", villainName);
                    villainId = villainFindCommand.ExecuteScalar();

                    if (villainId == null)
                    {
                        string insertVillainQuery = @"INSERT INTO Villains(Name,EvilnessFactorId) VALUES(@name,4)";
                        using (SqlCommand insertVillainCommand = new SqlCommand(insertVillainQuery, connection))
                        {
                            insertVillainCommand.Parameters.AddWithValue("@name", villainName);
                            insertVillainCommand.ExecuteNonQuery();
                            villainId = villainFindCommand.ExecuteScalar();
                            Console.WriteLine($"Villain {villainName} was added to the database.");
                        }
                    }
                    
                }
               
                string minionInsertQuery = @"INSERT INTO Minions(Name,Age,TownId) VALUES(@name, @age, @townId)";

                using (SqlCommand minionInsertCommand = new SqlCommand(minionInsertQuery, connection))
                {
                    minionInsertCommand.Parameters.AddWithValue("@name", minionName);
                    minionInsertCommand.Parameters.AddWithValue("@age", minionAge);
                    minionInsertCommand.Parameters.AddWithValue("@townId", townId);

                    minionInsertCommand.ExecuteNonQuery();
                }

                string minionIdQuery = @"SELECT Id FROM Minions WHERE Name=@name";
                object minionId = 0;

                using (SqlCommand minionIdCommand = new SqlCommand(minionIdQuery, connection))
                {
                    minionIdCommand.Parameters.AddWithValue("@name", minionName);
                    minionId = minionIdCommand.ExecuteScalar();
                }

                string minionsVillainsInsertQuery = @"INSERT INTO MinionsVillains VALUES (@minionId, @villainId)";

                using (SqlCommand minionsVillainsInsertCommand = new SqlCommand(minionsVillainsInsertQuery, connection))
                {
                    minionsVillainsInsertCommand.Parameters.AddWithValue("@minionId",minionId);
                    minionsVillainsInsertCommand.Parameters.AddWithValue("@villainId", villainId);
                    minionsVillainsInsertCommand.ExecuteNonQuery();
                    Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
                }

                connection.Close();
            }
        }
    }
}
