namespace DefiningClassesPart2
{
    using System.IO;
    using System.Text.RegularExpressions;

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

                DeleteSaveFiles();
                count = 0;
            }
        }

        public static Path LoadPath(string filePath = null)
        {
            Path currentPath = new Path();
            if (filePath == null)
            {
                filePath = PATH + FILE_NAME + count.ToString() + EXTENSION;
            }

            currentPath = new Path();
            ProcessFile(currentPath, filePath);
            return currentPath;
        }

        private static void DeleteSaveFiles()
        {
            for (int i = 0; i < MAX_NUMBER_OF_FILES; i++)
            {
                File.Delete(PATH + FILE_NAME + i.ToString() + EXTENSION);
            }
        }

        private static void ProcessFile(Path currentPath, string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string temp = reader.ReadLine();
                while (temp != null)
                {
                    double[] pointCoords = new double[3];
                    ExtractCoordinates(temp, pointCoords);
                    currentPath.AddPoint(new Point3D(pointCoords[0], pointCoords[1], pointCoords[2]));
                    temp = reader.ReadLine();
                }
            }
        }

        private static void ExtractCoordinates(string temp, double[] pointCoords)
        {
            int index = new int();
            string regex = @"\|?\s?[X-Z]{1}\s{1}coord:\s{1}|\s{1}";
            string[] line = Regex.Split(temp, regex);
            foreach (var coord in line)
            {
                if (coord != null && coord != string.Empty)
                {
                    pointCoords[index] = double.Parse(coord);
                    index++;
                }
            }
        }
    }
}
