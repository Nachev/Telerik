namespace DocumentSystem
{
    using System;
    using System.Linq;

    public abstract class OfficeDocument : BinaryDocument, IOfficeDocument
    {
        private string version;

        protected OfficeDocument(string initialName, string initialContent)
            : base(initialName, initialContent)
        {
        }

        public string Version
        {
            get
            {
                return this.version;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Version value cannot be null or empty.");
                }

                this.version = value;
            }
        }
    }
}
