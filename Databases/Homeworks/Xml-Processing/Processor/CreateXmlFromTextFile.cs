namespace XmlProcessor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    /*In a text file we are given the name, address and 
    phone number of given person (each at a single line). 
    Write a program, which creates new XML document, 
    which contains these data in structured XML format.*/
    internal class CreateXmlFromTextFile
    {
        public void ProcessPerson(string pathToTextFile, string pathToXmlFile)
        { 
            var inputValues = new List<string>(3);

            using (var reader = new StreamReader(pathToTextFile))
            {
                while (!reader.EndOfStream)
                {
                    var lineText = reader.ReadLine();
                    inputValues.Add(lineText);
                }
            }

            XElement result = new XElement("persons",
                new XElement("person",
                    new XElement("name", inputValues[0]),
                    new XElement("address", inputValues[1]),
                    new XElement("phone_number", inputValues[2])));

            result.Save(pathToXmlFile);
        }
    }
}