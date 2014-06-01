namespace DocumentSystem
{
    using System;
    using System.Linq;

    public class PDFDocument : BinaryDocument, IEncryptable, IPdfDocument
    {
        private int numberOfPages;

        public PDFDocument(string initialName, string initialContent = null) 
            : base(initialName, initialContent)
        {
        }
        
        public int NumberOfPages
        {
            get
            {
                return this.numberOfPages;
            }

            private set
            {
                this.numberOfPages = value;
            }
        }

        public bool IsEncrypted { get; private set; }

        public void Encrypt()
        {
            this.IsEncrypted = true;
        }

        public void Decrypt()
        {
            this.IsEncrypted = false;
        }
    }
}
