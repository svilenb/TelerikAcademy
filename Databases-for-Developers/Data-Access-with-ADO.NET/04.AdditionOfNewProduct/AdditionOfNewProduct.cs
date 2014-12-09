namespace _04.AdditionOfNewProduct
{
    using System;
    using System.Data.SqlClient;

    class AdditionOfNewProduct
    {
        static void Main(string[] args)
        {
            SqlConnection dbConnection = new SqlConnection("Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=true");
            dbConnection.Open();
            using(dbConnection)
            {
                SqlCommand commandInsertProduct = new SqlCommand("INSERT INTO Products (ProductName, Discontinued) VALUES (@productName, @discontinued)", dbConnection);
                commandInsertProduct.Parameters.AddWithValue("@productName", "pesho's product");
                commandInsertProduct.Parameters.AddWithValue("@discontinued", 0);
                commandInsertProduct.ExecuteNonQuery();
                SqlCommand cmdSelectIdentity = new SqlCommand("SELECT @@Identity", dbConnection);
                int insertedRecordId = (int)(decimal)cmdSelectIdentity.ExecuteScalar();
                Console.WriteLine("Inserted new product. ProductID = {0}", insertedRecordId);
            }
        }
    }
}
