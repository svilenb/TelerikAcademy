namespace _01.NumberOfRowsInCategories
{
    using System;
    using System.Data.SqlClient;

    class NumberOfRowsInCategories
    {
        static void Main(string[] args)
        {
            SqlConnection dbConnection = new SqlConnection("Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=true");
            dbConnection.Open();
            using(dbConnection)
	        {
		        SqlCommand commandCount = new SqlCommand("SELECT COUNT(*) FROM Categories", dbConnection);
                int categoriesCount = (int)commandCount.ExecuteScalar();
                Console.WriteLine("Categories count: {0}", categoriesCount);
	        }
        }
    }
}
