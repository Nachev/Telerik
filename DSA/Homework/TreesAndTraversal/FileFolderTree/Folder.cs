namespace FileFolderTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Folder
    {
        public Folder(string initialName)
        {
            this.Name = initialName;
        }

        public Folder(string initialName, ICollection<File> files, IList<Folder> childFolders)
            : this(initialName)
        {
            this.Files = files;
            this.ChildFolders = childFolders;
        }

        public IList<Folder> ChildFolders { get; private set; }

        public ICollection<File> Files { get; private set; }

        public string Name { get; private set; }

        public void AddChildFolder(Folder child)
        {
            this.ChildFolders.Add(child);
        }

        public void AddFile(File child)
        {
            this.Files.Add(child);
        }
    }
}