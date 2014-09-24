namespace XmlProcessor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;

    internal class TetsProgramEntry
    {
        private static void Main(string[] args)
        {
            const string PathToCatalogXmlFile = @"../../catalog.xml";
            try
            {
                //var domExtractor = new ExtractArtistsWithDom();
                //var extractedArtistsWithAlbumsCountWithDom = domExtractor.ExtractArtistsWithAlbumsCount(PathToCatalogXmlFile);
                //PrintDictionary(extractedArtistsWithAlbumsCountWithDom);

                //var xPathExtractor = new ExtractArtistsWithXPath();
                //var extractedWithXPath = xPathExtractor.ExtractArtistsWithAlbumsCount(PathToCatalogXmlFile);
                //PrintDictionary(extractedWithXPath);

                //var xmlDomEraser = new XmlDomEraser();
                //xmlDomEraser.DeleteExpensiveAlbums(PathToCatalogXmlFile, 20.00D);

                //var xmlReaderExtractor = new ExtractSongTitlesWithXmlReader();
                //var allSongsWithReader = xmlReaderExtractor.GetSongTitles(PathToCatalogXmlFile);
                //Console.WriteLine("All songs : {0}", string.Join(", ", allSongsWithReader));

                //var linqExtractor = new XDocumentAndLinqQuery();
                //var allSongsWithLinq = linqExtractor.GetSongTitles(PathToCatalogXmlFile);
                //Console.WriteLine("All songs : {0}", string.Join(", ", allSongsWithLinq));

                //var xmlFromText = new CreateXmlFromTextFile();
                //xmlFromText.ProcessPerson("../../PersonsInput.txt", "../../createdFromText.xml");

                //var xmlReaderWriter = new XmlReaderWriter();
                //xmlReaderWriter.CreateAlbumFromCatalog(PathToCatalogXmlFile, "../../albums.xml");

                var xmlWriterDirectories = new XmlWriterDirectories();
                var directoryInfo = new DirectoryInfo(@"../../../");
                xmlWriterDirectories.WalkDirectoryTree(0, directoryInfo);
            }
            catch (XmlException xmlEx)
            {
                Console.WriteLine("{0}", xmlEx.Message);
            }
            catch (ApplicationException ex) 
            {
                Console.WriteLine("{0}", ex.Message);
            }
        }

        private static void PrintDictionary(IDictionary<string, int> artistsWithAlbumsCount)
        {
            foreach(var artist in artistsWithAlbumsCount)
            {
                Console.WriteLine("artist: {0}, albums count: {1}", artist.Key, artist.Value);
            }
        }
    }
}
