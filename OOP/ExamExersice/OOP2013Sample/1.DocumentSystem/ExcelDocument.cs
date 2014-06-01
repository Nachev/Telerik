namespace DocumentSystem
{
    using System;
    using System.Linq;

    public class ExcelDocument : OfficeDocument, IExcelDocument, IEncryptable
    {
        private int numberOfRows;
        private int numberOfColumns;

        public ExcelDocument(string initialName, string initialContent) 
            : base(initialName, initialContent)
        {
        }

        public int NumberOfColumns
        {
            get
            {
                return this.numberOfColumns;
            }

            private set
            {
                this.numberOfColumns = value;
            }
        }

        public int NumberOfRows
        {
            get
            {
                return this.numberOfRows;
            }

            private set
            {
                this.numberOfRows = value;
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
