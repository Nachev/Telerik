namespace RetrieveFromDBNumberOfRows
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    /*Write a program that retrieves from the Northwind
    sample database in MS SQL Server the number of 
    rows in the Categories table. */
    public class GetNumberOfRows
    {
        private static void Main()
        {
            SqlConnection con = new SqlConnection(
                "Server=.;Database=Northwind; Integrated Security=true"); 
            con.Open();
            using (con)
            {
                SqlCommand cmdCount = new SqlCommand(
                    "SELECT COUNT(*) FROM Categories", con);
                int categoriesCount = (int)cmdCount.ExecuteScalar();
                Console.WriteLine("Categories count: {0} ", categoriesCount);
            }
        }
    }
}