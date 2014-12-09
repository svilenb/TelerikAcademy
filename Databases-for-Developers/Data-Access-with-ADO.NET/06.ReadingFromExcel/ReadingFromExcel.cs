namespace _06.ReadingFromExcel
{
    using System;
    using System.Data.OleDb;

    class ReadingFromExcel
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
                OleDbCommand resultsCommand = new OleDbCommand("SELECT * FROM [Sheet1$]", dbConn);
                OleDbDataReader reader = resultsCommand.ExecuteReader();
                while (reader.Read())
                {
                    string name = (string)reader["Name"];
                    double score = (double)reader["Score"];
                    Console.WriteLine("{0} - score: {1}", name, score);
                }
            }
        }
    }
}
