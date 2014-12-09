namespace _05.RetrievingImages
{
    using System;
    using System.IO;
    using System.Data.SqlClient;

    public class RetrievingImages
    {
        const string FILE_LOCATION = @"..\..\images\";
        const string FILE_EXTENSION = @".gif";
        const string CONNECTION_STRING = "Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=true";
        static void Main(string[] args)
        {
            ExtractImagesFromDB(CONNECTION_STRING);
        }      

        private static void WriteBinaryFile(string fileName, byte[] fileContents)
        {
            FileStream stream = File.OpenWrite(fileName);
            using (stream)
            {
                stream.Write(fileContents, 0, fileContents.Length);
            }
        }

        private static void ExtractImagesFromDB(string connectionString)
        {
            SqlConnection dbConn = new SqlConnection(connectionString);
            dbConn.Open();
            using (dbConn)
            {
                SqlCommand cmd = new SqlCommand("SELECT PICTURE, CategoryID, CategoryName FROM Categories", dbConn);                                                
                SqlDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    byte[] image;
                    int categoryID;
                    string categoryName;
                    while (reader.Read())
                    {
                        image = (byte[])reader["Picture"];
                        categoryID = (int)reader["CategoryID"];                        
                        WriteBinaryFile(FILE_LOCATION + categoryID + FILE_EXTENSION, image);                        
                    }

                    Console.WriteLine("Extracted all images!");
                }
            }
        }
    }
}
