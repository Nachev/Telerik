namespace GetNameAndDescriptionOfCategories
{
    using System;
    using System.Data.SqlClient;

    /*Write a program that retrieves the name and 
    description of all categories in the NorthwindDB.*/
    public class GetNameAndDescription
    {
        private static void Main()
        {
            SqlConnection con = new SqlConnection(
                "Server=.;Database=Northwind; Integrated Security=true");
            con.Open();
            using (con)
            {
                SqlCommand cmdCount = new SqlCommand(
                    "SELECT CategoryName, Description FROM Categories", con);
                using (var nameAndDescriptionReader = cmdCount.ExecuteReader())
                {
                    while (nameAndDescriptionReader.Read())
                    {
                        Console.WriteLine("Category name: {0}, description: {1},", nameAndDescriptionReader.GetValue(0), nameAndDescriptionReader.GetValue(1));
                    }
                }
            }
        }
    }
}