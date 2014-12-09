namespace _02.NameAndDescription
{
    using System;
    using System.Data.SqlClient;

    class NameAndDescription
    {
        static void Main(string[] args)
        {
            SqlConnection dbConnection = new SqlConnection("Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=true");
            dbConnection.Open();
            using (dbConnection)
            {
                SqlCommand commandAllCategories = new SqlCommand("SELECT CategoryName, Description FROM Categories", dbConnection);
                SqlDataReader reader = commandAllCategories.ExecuteReader();
                using (reader)
                {
                    Console.WriteLine("Categories:");
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string categoryDescription = (string)reader["Description"];                        
                        Console.WriteLine("Name: {0} Description: {1}", categoryName, categoryDescription);
                    }
                }
            }
        }
    }
}