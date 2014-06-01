namespace DocumentSystem
{
    using System;
    using System.Linq;

    public abstract class MultimediaDocument : BinaryDocument, IMultimediaDocument
    {
        private int length;

        protected MultimediaDocument(string initialName, string initialContent) 
            : base(initialName, initialContent)
        {
        }
        public int Length
        {
            get
            {
                return this.length;
            }

            private set
            {
                this.length = value;
            }
        }
    }
}
