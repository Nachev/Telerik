namespace ConsoleStringSearchInProduct
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;

    /*Write a program that reads a string from the console 
    and finds all products that contain this string. Ensure 
    you handle correctly characters like ', %, ", \and _. */

    internal class StringSearchInProducts
    {
        private static void Main()
        {
            Console.Write("Enter value to search for: ");
            string input = Console.ReadLine();
            string escaped = EscapeLikeValue(input);
            SerachInProducts(escaped);
        }
 
        private static void SerachInProducts(string input)
        {
            SqlConnection con = new SqlConnection(
                "Server=.;Database=Northwind; Integrated Security=true");
            con.Open();
            using (con)
            {
                SqlCommand cmdFindProduct = new SqlCommand(
                                                           "SELECT ProductName" +
                                                           " FROM Products" +
                                                           " WHERE ProductName LIKE '%' + @searchString + '%'", con);
                cmdFindProduct.Parameters.AddWithValue("@searchString", input);

                using (var prodNameReader = cmdFindProduct.ExecuteReader())
                {
                    while (prodNameReader.Read())
                    {
                        Console.WriteLine("Product name: {0}", prodNameReader.GetValue(0));
                    }
                }
            }
        }

        private static string EscapeLikeValue(string value)
        {
            StringBuilder result = new StringBuilder(value.Length);
            for (int i = 0; i < value.Length; i++)
            {
                char character = value[i];
                switch (character)
                {
                    case ']':
                    case '[':
                    case '%':
                    case '*':
                    case '_':
                    case '\\':
                        result.Append("[").Append(character).Append("]");
                        break;
                    case '\'':
                        result.Append("''");
                        break;
                    default:
                        result.Append(character);
                        break;
                }
            }

            return result.ToString();
        }
    }
}