namespace DocumentSystem
{
    using System;
    using System.Linq;

    public class WordDocument : OfficeDocument, IWordDocument, IEncryptable, IEditable
    {
        private string numberOfCharacters;

        public WordDocument(string initialName, string initialContent) 
            : base(initialName, initialContent)
        {
        }

        public string NumberOfCharacters
        {
            get
            {
                return this.numberOfCharacters;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Character's number cannot be null or empty.");
                }

                this.numberOfCharacters = value;
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

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}
