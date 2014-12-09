namespace _07.AddingRowsToExcel
{
    using System;
    using System.Data.OleDb;

    class AddingRowsToExcel
    {
        static void Main(string[] args)
        {
            OleDbConnectionStringBuilder connectionString = new OleDbConnectionStringBuilder();
            connectionString.Provider = "Microsoft.Jet.OLEDB.4.0";
            connectionString.DataSource = @"..\..\results.xls";
            connectionString.Add("Extended Properties", "Excel 8.0;HDR=YES");

            OleDbConnection dbConn = new OleDbConnection(connectionString.ConnectionString);
            dbConn.Open();
            using (dbConn)
            {
                OleDbCommand insertCommand = new OleDbCommand("INSERT INTO [Sheet1$] (Name,Score) VALUES (@Name, @Score)", dbConn);
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Score: ");
                int score = int.Parse(Console.ReadLine());
                insertCommand.Parameters.AddWithValue("@Name", name);
                insertCommand.Parameters.AddWithValue("@Score", score);
                insertCommand.ExecuteNonQuery();
            }
        }
    }
}
