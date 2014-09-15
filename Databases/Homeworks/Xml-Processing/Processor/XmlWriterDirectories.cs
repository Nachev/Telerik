namespace XmlProcessor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    internal class XmlWriterDirectories
    {
        private const char IndentationSymbol = '-';
        private IList<string> log;

        public XmlWriterDirectories()
        {
            this.log = new List<string>();
        }

        public IList<string> Log
        {
            get
            {
                return this.log;
            }
        }

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

        public void WalkDirectoryTree(int indentation, DirectoryInfo root)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;

            // First, process all the files directly under this folder 
            try
            {
                files = root.GetFiles("*.*");
            }
            catch (UnauthorizedAccessException e)
            {
                log.Add(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                indentation += 3;
                foreach (FileInfo fi in files)
                {
                    Console.WriteLine(new string(IndentationSymbol, indentation) + fi.Name);
                }

                indentation -= 3;

                // Now find all the subdirectories under this directory.
                subDirs = root.GetDirectories();

                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    indentation += 3;
                    Console.WriteLine(new string(IndentationSymbol, indentation) + dirInfo.Name);

                    // Resursive call for each subdirectory.
                    WalkDirectoryTree(indentation, dirInfo);
                    indentation -= 3;
                }
            }
        }
    }
}
