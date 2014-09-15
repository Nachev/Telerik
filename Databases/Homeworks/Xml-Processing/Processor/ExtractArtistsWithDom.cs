namespace XmlProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    /*Write program that extracts all different artists 
    which are found in the catalog.xml. For each 
    author you should print the number of albums in the 
    catalogue. Use the DOM parser and a hash-table.*/
    internal class ExtractArtistsWithDom
    {
        public IDictionary<string, int> ExtractArtistsWithAlbumsCount(string pathToFile)
        {
            XmlDocument catalog = new XmlDocument();
            catalog.Load(pathToFile);
            var result = new Dictionary<string, int>();
            var albums = catalog.GetElementsByTagName("album");

            // For each album in catalog.
            foreach (XmlElement album in albums)
            {
                // Get artist element.
                var artistElements = album.GetElementsByTagName("artist");

                // Check if there is an artist.
                if (artistElements.Count == 0)
                {
                    continue;
                }

                // Get artist name
                string artistName = artistElements[0].InnerText;

                // If current artist exists in the dictionary.
                if (result.ContainsKey(artistName))
                {
                    // Add this album to the count.
                    result[artistName]++;
                }
                else
                {
                    // Add current artist to the dictionary.
                    result.Add(artistName, 1);
                }
            }

            return result;
        }
    }
}