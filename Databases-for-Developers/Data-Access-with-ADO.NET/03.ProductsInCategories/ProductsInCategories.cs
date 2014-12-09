namespace _03.ProductsInCategories
{
    using System;
    using System.Data.SqlClient;

    class ProductsInCategories
    {
        static void Main(string[] args)
        {
            SqlConnection dbConnection = new SqlConnection("Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=true");
            dbConnection.Open();
            using (dbConnection)
            {
                SqlCommand commandAllCategories = new SqlCommand("SELECT c.CategoryName, p.ProductName FROM Categories c INNER JOIN Products p ON c.CategoryID = p.CategoryID", dbConnection);
                SqlDataReader reader = commandAllCategories.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string productName = (string)reader["ProductName"];                        
                        Console.WriteLine("Category Name: {0} --- Product Name: {1}", categoryName, productName);
                    }
                }
            }
        }
    }
}
