namespace DocumentSystem
{
    using System;
    using System.Linq;

    public class AudioDocument : MultimediaDocument, IAudioDocument
    {
        private int sampleRate;

        public AudioDocument(string initialName, string initialContent)
            : base(initialName, initialContent)
        {
        }

        public int SampleRate
        {
            get
            {
                return this.sampleRate;
            }

            private set
            {
                this.sampleRate = value;
            }
        }
    }
}
