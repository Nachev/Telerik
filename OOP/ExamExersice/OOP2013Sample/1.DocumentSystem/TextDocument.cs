namespace DocumentSystem
{
    using System;
    using System.Linq;

    public class TextDocument : Document, ITextDocument, IEditable
    {
        private string charset;

        public TextDocument(string initialName, string initialContent = null)
            : base(initialName, initialContent)
        {
        }

        public string Charset
        {
            get
            {
                return this.charset;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Charset cannot be null or empty.");
                }

                this.charset = value;
            }
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}
