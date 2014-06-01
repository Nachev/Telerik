﻿namespace AStarPathfinding
{
    using System;
    using System.IO;
    using System.Xml.Serialization;

    public class XmlManager<T>
    {
        public Type Type { get; private set; }

        public T Load(string path)
        {
            T instance;
            using(TextReader reader = new StreamReader(path))
            {
                XmlSerializer xml = new XmlSerializer(this.Type);
                instance = (T)xml.Deserialize(reader);
            }

            return instance;
        }

        public void Save(string path, object obj)
        {
            using(TextWriter writer = new StreamWriter(path))
            {
                XmlSerializer xml = new XmlSerializer(this.Type);
                xml.Serialize(writer, obj);
            }
        }
    }
}
