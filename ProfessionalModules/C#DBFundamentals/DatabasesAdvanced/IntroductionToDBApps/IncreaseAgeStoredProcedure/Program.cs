using IntroductionToDBApps;
using System;
using System.Data.SqlClient;

namespace IncreaseAgeStoredProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            int minionId = int.Parse(Console.ReadLine().Trim());

            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                connection.Open();

                string callProcedureQuery = "EXEC dbo.usp_GetOlder @id";

                using (SqlCommand callProcedureCommand=new SqlCommand(callProcedureQuery,connection))
                {
                    callProcedureCommand.Parameters.AddWithValue("@id",minionId);
                    callProcedureCommand.ExecuteNonQuery();
                }

                string getMinionQuery = "SELECT Name, Age FROM Minions WHERE Id=@id";

                using (SqlCommand getMinionCommand=new SqlCommand(getMinionQuery,connection))
                {
                    getMinionCommand.Parameters.AddWithValue("@id", minionId);
                    using (SqlDataReader reader=getMinionCommand.ExecuteReader())
                    {
                        reader.Read();
                        Console.WriteLine($"{reader["Name"]} – {reader["Age"]} years old");
                    }
                }

                connection.Close();
            }
        }
    }
}
