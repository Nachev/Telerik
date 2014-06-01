namespace DocumentSystem
{
    using System;
    using System.Linq;

    public abstract class BinaryDocument : Document, IBinaryDocument
    {
        private string size;

        protected BinaryDocument(string initialName, string initialContent)
            : base(initialName, initialContent)
        {

        }
        
        public string Size
        {
            get
            {
                return this.size;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Size cannot be null or empty.");
                }

                this.size = value;
            }
        }
    }
}
