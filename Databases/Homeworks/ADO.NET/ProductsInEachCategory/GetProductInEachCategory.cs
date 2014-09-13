namespace ProductsInEachCategory
{
    using System;
    using System.Data.SqlClient;

    /*Write a program that retrieves from the Northwind
    database all product categories and the names of 
    the products in each category .  Can you do this with a 
    single SQL query (with table join)? */
    public class GetProductInEachCategory
    {
        private static void Main()
        {
            SqlConnection con = new SqlConnection(
                "Server=.;Database=Northwind; Integrated Security=true");
            con.Open();
            using (con)
            {
                SqlCommand cmdCount = new SqlCommand(
                    "SELECT cat.CategoryName, prod.ProductName" + 
                    " FROM Categories cat INNER JOIN Products prod" + 
                    " ON cat.CategoryID = prod.CategoryID" +
                    " ORDER BY cat.CategoryID", con);
                using (var catNameAndProdNameReader = cmdCount.ExecuteReader())
                {
                    while (catNameAndProdNameReader.Read())
                    {
                        Console.WriteLine("Category name: {0}, product name: {1},", catNameAndProdNameReader.GetValue(0), catNameAndProdNameReader.GetValue(1));
                    }
                }
            }
        }
    }
}