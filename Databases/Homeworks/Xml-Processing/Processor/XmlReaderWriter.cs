namespace XmlProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    /*Write a program, which (using XmlReader and
    XmlWriter) reads the file catalog.xml and creates 
    the file album.xml, in which stores in appropriate 
    way the names of all albums and their authors.*/
    internal class XmlReaderWriter
    {
        public void CreateAlbumFromCatalog(string pathToInputXml, string pathToOutputXml)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            settings.Encoding = Encoding.UTF8;
            IList<Album> albums = new List<Album>();

            using (var reader = new XmlTextReader(pathToInputXml))
            {
                var currentAlbum = new Album();

                while (reader.Read())
                {
                    switch (reader.Name)
                    {
                        case "album":
                            currentAlbum = new Album();
                            break;
                        case "name":
                            currentAlbum.Name = reader.Value;
                            break;
                        case "artist":
                            currentAlbum.Artist = reader.Value;
                            break;
                        case "songs":
                            albums.Add(currentAlbum);
                            break;
                        default:
                            break;
                    }
                }
            }

            using (var writer = XmlWriter.Create(pathToOutputXml, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("albums");
                foreach (var album in albums)
                {
                    writer.WriteStartElement("album");
                    writer.WriteElementString("name", album.Name);
                    writer.WriteElementString("artist", album.Artist);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.Flush();
            }
        }
    }

    internal class Album
    {
        public string Artist { get; set; }

        public string Name { get; set; }
        
        public Album()
        {
        }
    }
}