namespace ManipulateExcelFile
{
    using System;
    using System.Linq;
    using System.Data.OleDb;

    internal class ReadWriteExcel
    {
        private static void Main(string[] args)
        {
            string connectionString = "Provider=Microsoft.Jet.OleDb.4.0; data source=../../NameScoreTable.xls; Extended Properties=Excel 8.0;";

            // Select using a Named Range
            //string selectString = "SELECT * FROM TableForExcersize";
            
            // Select using a Worksheet name
            string selectString = "SELECT * FROM [Sheet1$]";
            string insertString = "INSERT INTO [Sheet1$] VALUES (@name, @score)";

            var con = new OleDbConnection(connectionString);
            var selectCmd = new OleDbCommand(selectString, con);
            var insertCmd = new OleDbCommand(insertString, con);
            string insertName = "Grigor Grigorov";
            string insertScore = "100";
            insertCmd.Parameters.AddWithValue("@name", insertName);
            insertCmd.Parameters.AddWithValue("@score", insertScore);

            try
            {
                con.Open();
                using (var theData = selectCmd.ExecuteReader())
                {
                    while (theData.Read())
                    {
                        Console.WriteLine("Name: {0}, Score: {1}", theData.GetValue(0), theData.GetValue(1));
                    }
                }

                var insertedRows = insertCmd.ExecuteNonQuery(); 
                Console.WriteLine("Inserted {0} rows ", insertedRows);
            }
            catch (InvalidOperationException invOpEx)
            {
                Console.WriteLine(invOpEx.Message);
            }
            catch (OleDbException oleDbEx)
            {
                Console.WriteLine(oleDbEx);
            }
            finally
            {
                con.Dispose();
            }
        }
    }
}