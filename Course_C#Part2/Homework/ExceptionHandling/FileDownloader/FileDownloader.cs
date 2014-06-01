namespace FileDownloader
{
    using System;
    using System.Net;

    public class FileDownloader
    {
        private static void Main()
        {
            Console.Title = "File downloader";

            try
            {
                DownloadFile();
            }
            catch (ArgumentNullException argNull)
            {
                Console.WriteLine("Exception: {0}", argNull.Message);
            }
            catch (WebException webEx)
            {
                Console.WriteLine("Exception: {0}", webEx.Message);
            }
            catch(NotSupportedException notSupported)
            {
                Console.WriteLine("Exception: {0}", notSupported.Message);
            }
        }

        private static void DownloadFile()
        {
            string address = @"http://www.telerik.com/libraries/thumbnails/telerik-logo.sflb";
            string filePath = @"../../image.img";
            WebClient webClient = new WebClient();
            webClient.DownloadFile(address, filePath);
        }
    }
}
