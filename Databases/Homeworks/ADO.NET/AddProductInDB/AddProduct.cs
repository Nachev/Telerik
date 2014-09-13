namespace AddProductInDB
{
    using System;
    using System.Data.SqlClient;

    /*Write a method that adds a new product in the 
    products table in the Northwinddatabase.  Use a 
    parameterized SQL command. 
    6*/
    public class AddProduct
    {
        private static void Main()
        {
            SqlConnection con = new SqlConnection(
                "Server=.;Database=Northwind; Integrated Security=true");
            con.Open();
            using (con)
            {
                InsertProduct(con, "Tsatsa", 13, 8, "100gr.", 1.90M);
            }
        }

        private static void InsertProduct(SqlConnection dbCon, string name, int suppID, int catID, string quantityPerUnit, decimal unitPrice)
        {
            SqlCommand cmdInsert = new SqlCommand("INSERT INTO Products " +
                "(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) VALUES " +
                "(@name, @suppID, @catID, @quantityPerUnit, @unitPrice, @unitsInStock, @unitsInOrder, @reorderedLevel, @discontinued)", dbCon);
            cmdInsert.Parameters.AddWithValue("@name", name);
            cmdInsert.Parameters.AddWithValue("@suppID", suppID);
            cmdInsert.Parameters.AddWithValue("@catID", catID);
            cmdInsert.Parameters.AddWithValue("@quantityPerUnit", quantityPerUnit);
            cmdInsert.Parameters.AddWithValue("@unitPrice", unitPrice);
            cmdInsert.Parameters.AddWithValue("@unitsInStock", DBNull.Value);
            cmdInsert.Parameters.AddWithValue("@unitsInOrder", DBNull.Value);
            cmdInsert.Parameters.AddWithValue("@reorderedLevel", DBNull.Value);
            cmdInsert.Parameters.AddWithValue("@discontinued", false);
            cmdInsert.ExecuteNonQuery();
        }
    }
}