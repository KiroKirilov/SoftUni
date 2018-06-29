using IntroductionToDBApps;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace RemoveVillain
{
    class Program
    {
        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine().Trim());

            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                connection.Open();

                Villain villain = GetVillainById(villainId, connection);

                if (villain == null)
                {
                    Console.WriteLine("No such villain was found.");
                }
                else
                {
                    string deleteMinionVillainsQuery = "DELETE MinionsVillains WHERE VillainId=@id";
                    int minionsReleased = 0;

                    using (SqlCommand deleteMinionVillainsCommand=new SqlCommand(deleteMinionVillainsQuery,connection))
                    {
                        deleteMinionVillainsCommand.Parameters.AddWithValue("@id",villain.Id);
                        minionsReleased = deleteMinionVillainsCommand.ExecuteNonQuery();
                    }

                    string deleteVillainQuery = "DELETE Villains WHERE Id=@id";

                    using (SqlCommand deleteVillainCommand=new SqlCommand(deleteVillainQuery,connection))
                    {
                        deleteVillainCommand.Parameters.AddWithValue("@id",villain.Id);
                    }

                    Console.WriteLine($"{villain.Name} was deleted.");
                    Console.WriteLine($"{minionsReleased} minions were released.");
                }

                connection.Close();
            }
        }

        private static Villain GetVillainById(int villainId, SqlConnection connection)
        {
            string getVillainQuery = @"SELECT Id, Name FROM Villains WHERE Id=@id";

            using (SqlCommand getVillainCommand=new SqlCommand(getVillainQuery,connection))
            {
                getVillainCommand.Parameters.AddWithValue("@id",villainId);

                using (SqlDataReader reader=getVillainCommand.ExecuteReader())
                {
                    reader.Read();
                   

                    if (!reader.HasRows)
                    {
                        return null;
                    }
                    else
                    {
                        int foundVillainId = int.Parse(reader["Id"].ToString());
                        string foundVillainName = reader["Name"].ToString();
                        return new Villain(foundVillainId,foundVillainName);
                    }
                }
            }
        }
    }
}
