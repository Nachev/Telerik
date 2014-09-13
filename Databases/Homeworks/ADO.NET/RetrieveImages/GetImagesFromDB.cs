namespace RetrieveImages
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;

    /*Write a program that retrieves the images for all 
    categories in the Northwinddatabase and stores 
    them as JPG files in the file system. */
    internal class GetImagesFromDB
    {
        private static void Main(string[] args)
        {
            var images = GetImages();
            int count = 0;
            foreach (var image in images)
            {
                SaveToDisk(image, count);
                count++;
            }
        }

        private static IEnumerable<byte[]> GetImages()
        {
            var result = new List<byte[]>();

            const string query = "SELECT Picture FROM Categories";
            using (var conn = new SqlConnection("Server=.; Database=Northwind; Integrated security=true"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                using (var dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        result.Add((byte[])dataReader.GetValue(0));
                    }
                }
            }

            return result;
        }

        private static void SaveToDisk(byte[] bitmap, int count)
        {
            using (Image image = Image.FromStream(new MemoryStream(bitmap, 78, bitmap.Length - 78)))
            {
                image.Save(string.Format("./output{0}.jpg", count), ImageFormat.Jpeg);  // Or Png
            }
        }
    }
}