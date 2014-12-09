namespace _09.MySQLBooks
{
    using System;
    using System.Threading;
    using System.Globalization;

    using MySql.Data;
    using MySql.Data.MySqlClient;

    class MySQLBooks
    {
        private static string pass;
        private static string connectionStr;

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Enter pass: ");
            pass = Console.ReadLine();
            connectionStr = "Server=localhost;Database=BooksDB;Uid=root;Pwd=" + pass + ";";
            ListAllBooks();
            Console.Write("Enter book title to search: ");
            ListBookByTitle(Console.ReadLine());
            Console.WriteLine("Adding book!");
            Console.Write("Enter book title: ");
            string addTitle = Console.ReadLine();
            Console.Write("Enter book author: ");
            string addAuthor = Console.ReadLine();
            Console.Write("Enter book publish date: ");
            DateTime addDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter book ISBN: ");
            string addISBN = Console.ReadLine();
            AddBook(addTitle, addAuthor, addDate, addISBN);
        }

        private static void ListAllBooks()
        {
            MySqlConnection connection = new MySqlConnection(connectionStr);
            connection.Open();
            using (connection)
            {
                MySqlCommand command = new MySqlCommand("select * from books", connection);
                MySqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("All Books: ");
                while (reader.Read())
                {
                    string title = (string)reader["Title"];
                    string author = (string)reader["Author"];
                    DateTime publishDate = (DateTime)reader["PublishDate"];
                    Console.WriteLine("{0} - {1} - {2}", title, author, publishDate);
                }
            }
        }

        private static void ListBookByTitle(string bookTitle)
        {
            MySqlConnection connection = new MySqlConnection(connectionStr);
            connection.Open();
            using (connection)
            {
                MySqlCommand findCommand = new MySqlCommand("SELECT Title, Author, PublishDate FROM Books WHERE title ='" + bookTitle + "';", connection);
                var reader = findCommand.ExecuteReader();
                while (reader.Read())
                {
                    string title = (string)reader["Title"];
                    string author = (string)reader["Author"];
                    DateTime publishDate = (DateTime)reader["PublishDate"];
                    Console.WriteLine("Searched book: ");
                    Console.WriteLine("{0} - {1} - {2}", title, author, publishDate);
                }
            }
        }

        static void AddBook(string title, string author, DateTime date, string ISBN)
        {
            MySqlConnection connection = new MySqlConnection(connectionStr);
            connection.Open();
            using (connection)
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO booksdb.books (Title, Author, Publishdate, ISBN) VALUES (@title, @author, @publishDate, @ISBN)", connection);
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@author", author);
                command.Parameters.AddWithValue("@publishDate", date);
                command.Parameters.AddWithValue("@ISBN", ISBN);
                command.ExecuteNonQuery();
                Console.WriteLine("Book added!");
            }
        }
    }
}
