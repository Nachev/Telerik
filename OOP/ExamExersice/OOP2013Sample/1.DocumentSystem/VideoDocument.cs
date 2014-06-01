namespace DocumentSystem
{
    using System;
    using System.Linq;

    public class VideoDocument : MultimediaDocument, IVideoDocument
    {
        private int frameRate;

        public VideoDocument(string initialName, string initialContent)
            : base(initialName, initialContent)
        {
        }

        public int FrameRate
        {
            get
            {
                return this.frameRate;
            }

            private set
            {
                this.frameRate = value;
            }
        }
    }
}
