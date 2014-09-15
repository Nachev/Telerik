namespace XmlProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    /*Write program that extracts all different artists 
    which are found in the catalog.xml. For each 
    author you should print the number of albums in the 
    catalogue. Use the DOM parser and a hash-table.
     * 
    !. Implement the previous using XPath.*/
    internal class ExtractArtistsWithXPath
    {
        private const string FakeNamespace = "fakeNS";

        public IDictionary<string, int> ExtractArtistsWithAlbumsCount(string pathToFile)
        {
            XmlDocument catalog = new XmlDocument();
            catalog.Load(pathToFile);

            // Manage fake namespace
            var xmlNs = catalog.DocumentElement.NamespaceURI;
            var xmlnsManager = new XmlNamespaceManager(catalog.NameTable);
            xmlnsManager.AddNamespace(FakeNamespace, xmlNs);

            var result = new Dictionary<string, int>();
            string xPathQuery = string.Format("{0}:albums/{1}:album", FakeNamespace, FakeNamespace);
            var albums = catalog.SelectNodes(xPathQuery, xmlnsManager);

            // For each album in catalog.
            foreach (XmlNode album in albums)
            {
                // Get artist element.
                var artistElement = album.SelectSingleNode(string.Format("{0}:artist", FakeNamespace), xmlnsManager);

                // Get artist name
                string artistName = artistElement.InnerText;

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