namespace XmlProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    /*Write a program, which using XmlReader extracts 
    all song titles from catalog.xml*/
    internal class ExtractSongTitlesWithXmlReader
    {
        public IEnumerable<string> GetSongTitles(string pathToFile)
        {
            IList<string> result = new List<string>();

            using(var reader = new XmlTextReader(pathToFile))
            {
                var ns = reader.NamespaceURI;
                while (reader.Read())
                {
                    if (reader.Name == ns + "song")
                    {
                        result.Add(reader.GetAttribute(0));
                    }
                }
            }

            return result;
        }
    }
}