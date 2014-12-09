namespace _08.AllProductsContainingString
{
    using System;
    using System.Data.SqlClient;
    using System.Text;

    class AllProductsContainingString
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the search parameter: ");
            string searchParameter = ParseString(Console.ReadLine());
            ListProducts(searchParameter);
        }

        private static string ParseString(string input)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '\'':
                        result.Append("[\']");
                        break;
                    case '%':
                        result.Append("[%]");
                        break;
                    case '"':
                        result.Append("[\"]");
                        break;
                    case '\\':
                        result.Append("[\\]");
                        break;
                    case '_':
                        result.Append("[_]");
                        break;
                    default:
                        result.Append(input[i]);
                        break;
                }
            }

            return result.ToString();
        }

        private static void ListProducts(string searchParameter)
        {
            SqlConnection dbConnection = new SqlConnection("Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=true");
            dbConnection.Open();
            using (dbConnection)
            {
                SqlCommand findProductsCommand = new SqlCommand("SELECT ProductName FROM Products WHERE ProductName Like @searchParameter", dbConnection);
                findProductsCommand.Parameters.AddWithValue("@searchParameter", "%" + searchParameter + "%");
                SqlDataReader reader = findProductsCommand.ExecuteReader();
                while (reader.Read())
                {
                    string product = (string)reader["ProductName"];
                    Console.WriteLine(product);
                }
            }
        }
    }
}
