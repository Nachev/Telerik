namespace MySqlManipulation
{
    using System;
    using System.Linq;
    using System.Data.Common;
    using MySql.Data.MySqlClient;

    /*Download and install MySQLdatabase, MySQL 
    Connector/Net  (.NET Data Provider for MySQL) + 
    MySQL WorkbenchGUI administration tool . Create 
    a MySQL database to store Books(title, author, 
    publish date and ISBN). Write methods for listing all 
    books, finding a book by name and adding a book. */

    internal class MySqlManipulation
    {
        private const string ConnectionString = "Network Address=localhost;" +
                                                "Database='bookstore';" +
                                                "Persist Security Info=no;" +
                                                "User Name='root';" +
                                                "Password=''";

        private static void Main(string[] args)
        {
            var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            using (connection)
            {
                AddBook(connection, "The Black Echo", "Michael Connelly", new DateTime(1992, 01, 21), "0-316-15361-3");
                SelectAllBooks(connection);
                Console.WriteLine("Search: ");
                FindBookByName(connection, "lack");
            }
        }

        private static void AddBook(MySqlConnection connection, string title, string author, DateTime publishDate, string isbn)
        {
            string commandStr = "INSERT INTO `bookstore`.`books`" +
                                "(`title`," +
                                "`author`," +
                                "`publishDate`," +
                                "`ISBN`)" +
                                "VALUES" +
                                "(@title," +
                                "@author," +
                                "@publishDate," +
                                "@ISBN);";
            
            MySqlCommand cmd = new MySqlCommand(commandStr, connection);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@author", author);
            cmd.Parameters.AddWithValue("@publishDate", publishDate);
            cmd.Parameters.AddWithValue("@ISBN", isbn);
            cmd.ExecuteNonQuery();
        }

        private static void FindBookByName(MySqlConnection connection, string searchStr)
        {
            string commandStr = "SELECT * FROM `bookstore`.`books`" +
                                "WHERE `title` LIKE @searchString";

            MySqlCommand cmd = new MySqlCommand(commandStr, connection);
            cmd.Parameters.AddWithValue("@searchString", '%' + searchStr + '%');

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["booksID"] + "\t" + reader["title"] + "\t" + reader["author"] + "\t" + reader["publishDate"] + "\t" + reader["ISBN"]);
                }
            }
        }

        private static void SelectAllBooks(DbConnection connection)
        {
            string commandStr = "SELECT * FROM books";
            var command = connection.CreateCommand();
            command.CommandText = commandStr;

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["booksID"] + "\t" + reader["title"] + "\t" + reader["author"] + "\t" + reader["publishDate"] + "\t" + reader["ISBN"]);
                }
            }
        }
    }
}