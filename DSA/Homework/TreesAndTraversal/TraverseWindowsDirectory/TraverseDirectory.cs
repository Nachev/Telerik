namespace TraverseWindowsDirectory
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal class TraverseDirectory
    {
        private const string RootPath = "C:\\Windows";

        private static void Main(string[] args)
        {
            var executionStack = new Stack<string>();
            executionStack.Push(RootPath);

            while (executionStack.Count > 0)
            {
                string currentDirectory = executionStack.Pop();
                try
                {
                    var exeFiles = Directory.GetFiles(currentDirectory, "*.exe", SearchOption.TopDirectoryOnly);
                    foreach (var file in exeFiles)
                    {
                        Console.WriteLine(Path.GetFileName(file));
                    }

                    var dirCollection = Directory.EnumerateDirectories(currentDirectory, "*", SearchOption.TopDirectoryOnly);

                    foreach (var dir in dirCollection)
                    {
                        executionStack.Push(dir);
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}