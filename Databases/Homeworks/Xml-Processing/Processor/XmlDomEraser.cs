namespace XmlProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    /*Using the DOM parser write a program to delete 
    from catalog.xml all albums having price > 20.*/
    internal class XmlDomEraser
    {
        public void DeleteExpensiveAlbums(string pathToXml, double maximallPrice)
        {
            XmlDocument catalog = new XmlDocument();
            catalog.Load(pathToXml);

            var albums = catalog.GetElementsByTagName("album");
            IList<XmlNode> nodesToDelete = new List<XmlNode>();

            // For each album in catalog.
            foreach (XmlElement album in albums)
            {
                // Get artist element.
                var albumPrice = album.GetAttributeNode("price");

                if (double.Parse(albumPrice.Value) > maximallPrice)
                {
                    nodesToDelete.Add(album);
                }
            }

            foreach (var node in nodesToDelete)
            {
                catalog.DocumentElement.RemoveChild(node);
            }

            catalog.Save(pathToXml);
        }
    }
}