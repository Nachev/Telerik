namespace FileFolderTree
{
    using System;
    using System.Linq;

    public class File
    {
        private string name;
        private int size;

        public File(string name, int size)
        {
            this.name = name;
            this.size = size;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public int Size
        {
            get
            {
                return this.size;
            }
        }
    }
}