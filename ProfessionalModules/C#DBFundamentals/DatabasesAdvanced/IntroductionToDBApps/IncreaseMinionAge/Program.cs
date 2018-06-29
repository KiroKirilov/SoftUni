using IntroductionToDBApps;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace IncreaseMinionAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] minionIds = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                connection.Open();
                string updateMinionsQuery = @"UPDATE Minions SET Age+=1, Name=CONCAT(UPPER(LEFT(Name,1)),LOWER(RIGHT(Name,LEN(Name)-1))) WHERE Id=@id";

                using (SqlCommand updateMinionsCommand = new SqlCommand(updateMinionsQuery, connection))
                {
                    foreach (var id in minionIds)
                    {
                        updateMinionsCommand.Parameters.Clear();
                        updateMinionsCommand.Parameters.AddWithValue("@id", id);
                        updateMinionsCommand.ExecuteNonQuery();
                    }
                }

                string getMinionsQuery = "SELECT Name, Age FROM Minions";

                using (SqlCommand getMinionsCommand = new SqlCommand(getMinionsQuery, connection))
                {
                    using (SqlDataReader reader = getMinionsCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
                        }
                    }
                }

                connection.Close();
            }
        }
    }
}
