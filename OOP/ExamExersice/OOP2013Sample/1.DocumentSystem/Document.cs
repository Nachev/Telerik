namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Document : IDocument
    {
        private string name;
        private string content;
        private IList<KeyValuePair<string, object>> properties;

        protected Document(string initialName, string initialContent = null)
        {
            this.Name = initialName;
            this.Content = initialContent;
            this.properties = new List<KeyValuePair<string, object>>();
            InitializePropertiesList();
        }

        public string Name
        {
            get 
            {
                return this.name; 
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Document must have a name.");
                }

                this.name = value;
            }
        }

        public string Content 
        {
            get
            {
                return this.content;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Content cannot be null or empty.");
                }

                this.content = value;
            }
        }

        public void LoadProperty(string key, string value)
        {
            var propertyList = this.GetType().GetProperties();
            this.properties = propertyList.Select(p => new KeyValuePair<string, object>(p.Name, p.GetValue(this))).ToList();
        }

        public void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            foreach (var property in this.properties)
            {
                var newEntry = new KeyValuePair<string, object>(property.Key, property.Value);
                output.Add(newEntry);
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(this.GetType().Name).Append("[");

            foreach (var property in this.properties)
            {
                result.AppendFormat("{0}={1};", property.Key, property.Value);
            }

            // Removes last ; (semicolon)
            result.Length -= 1;
            result.Append("]");

            return result.ToString();
        }

        private void InitializePropertiesList()
        {
            var propertyList = this.GetType().GetProperties();
            this.properties = propertyList.Select(p => new KeyValuePair<string, object>(p.Name, p.GetValue(this))).ToList();
            
            //foreach (var property in propertyList)
            //{
            //    this.properties.Add(property.Name, property.GetValue(this));
            //}
        }
    }
}
