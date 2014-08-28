namespace BookstoreSqlite
{
    using System;
    using System.Data.Common;
    using System.Linq;
    using System.Data.SQLite;

    /*Re-implement the previous task with SQLite 
    embedded DB (see http://http://www.sqlite.org/docs.html).*/
    internal class SqliteManipulation
    {
        private const string ConnectionString = "Data Source=Bookstore.sqlite;Version=3";

        private static void Main(string[] args)
        {
            SQLiteConnection.CreateFile("Bookstore.sqlite");
            var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using (connection)
            {
                CreateTable(connection);
                AddBook(connection, "Killing Floor", "Lee Child", new DateTime(1997, 03, 01), "0-515-12344-7");
                AddBook(connection, "The Black Echo", "Michael Connelly", new DateTime(1992, 01, 21), "0-316-15361-3");
                SelectAllBooks(connection);
                Console.WriteLine("Search: ");
                FindBookByName(connection, "lack");
            }
        }

        private static void CreateTable(SQLiteConnection connection)
        {
            string creationStr = "CREATE TABLE books (" +
                                 "booksID INTEGER PRIMARY KEY," +
                                 "title varchar(45) DEFAULT NULL," +
                                 "author varchar(45) DEFAULT NULL," +
                                 "publishDate datetime DEFAULT NULL," +
                                 "ISBN varchar(13) DEFAULT NULL)";

            var cmd = new SQLiteCommand(creationStr, connection);
            cmd.ExecuteNonQuery();
        }

        private static void AddBook(SQLiteConnection connection, string title, string author, DateTime publishDate, string isbn)
        {
            string commandStr = "INSERT INTO books" +
                                "(title, author, publishDate, ISBN)" +
                                "VALUES" +
                                "(@title," +
                                "@author," +
                                "@publishDate," +
                                "@ISBN);";

            var cmd = new SQLiteCommand(commandStr, connection);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@author", author);
            cmd.Parameters.AddWithValue("@publishDate", publishDate);
            cmd.Parameters.AddWithValue("@ISBN", isbn);
            cmd.ExecuteNonQuery();
        }

        private static void FindBookByName(SQLiteConnection connection, string searchStr)
        {
            string commandStr = "SELECT * FROM books " +
                                "WHERE title LIKE @searchString";

            var cmd = new SQLiteCommand(commandStr, connection);
            cmd.Parameters.AddWithValue("@searchString", "%" + searchStr + "%");

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