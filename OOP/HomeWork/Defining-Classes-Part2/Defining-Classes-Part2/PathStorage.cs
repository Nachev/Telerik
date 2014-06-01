namespace Defining_Classes_Part2
{
    using System.IO;

    /*Create a static class PathStorage with static methods to save 
     * and load paths from a text file. Use a file format of your choice.*/

    public static class PathStorage
    {
        private const string PATH = @"..\..\";
        private const string FILE_NAME = "SaveFile";
        private const string EXTENSION = ".pth";
        private const int MAX_NUMBER_OF_FILES = 50;

        private static int count = new int();

        public static void SavePath(Path spacePath)
        {
            while (true)
            {
                for (int i = count; i < MAX_NUMBER_OF_FILES; i++)
                {
                    string currentFilePath = PATH + FILE_NAME + i.ToString() + EXTENSION;
                    if (!File.Exists(currentFilePath))
                    {
                        File.WriteAllText(currentFilePath, spacePath.ToString());
                        count = i;
                        return;
                    }
                }

                for (int i = 0; i < MAX_NUMBER_OF_FILES; i++)
                {
                    File.Delete(PATH + FILE_NAME + i.ToString() + EXTENSION);
                }
            }
        }
    }
}
