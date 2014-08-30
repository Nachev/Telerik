namespace TraverseTask
{
    using FileFolderTree;
    using System;
    using System.IO;
    using System.Linq;

    internal class FileSystemTraversal
    {
        private const string RootPath = "C:\\Windows";
        private Folder currentFolder;
        private File currentFile;

        private static void Main(string[] args)
        {

        }

        private static void Traverse(string currentDirectory)
        {
            try
            {
                var exeFiles = Directory.GetFiles(currentDirectory, "*.exe", SearchOption.TopDirectoryOnly);
                foreach (var file in exeFiles)
                {
                    Path.GetFileName(file));
                }

                var dirCollection = Directory.EnumerateDirectories(currentDirectory, "*", SearchOption.TopDirectoryOnly);

                foreach (var dir in dirCollection)
                {
                    Traverse(dir);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}