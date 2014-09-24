namespace XmlProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;

    /*Write a program, which using XmlReader extracts 
    all song titles from catalog.xml.
    !. Rewrite the same using XDocument and LINQ query.*/
    internal class XDocumentAndLinqQuery
    {
        public IEnumerable<string> GetSongTitles(string pathToFile)
        {
            IList<string> result = new List<string>();

            using (var reader = new XmlTextReader(pathToFile))
            {
                XDocument xDoc = XDocument.Load(reader);
                var ns = xDoc.Document.Root.GetDefaultNamespace();
                result = xDoc.Descendants(ns + "song").Select(s => s.FirstAttribute.Value).ToList();
            }

            return result;
        }
    }
}