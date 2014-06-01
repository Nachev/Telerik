namespace AStarPathfinding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;

    public static class TxtMapReader
    {
        private static int width;
        private static int height;

        public static int[,] Loader(string path)
        {
            List<int[]> layout = new List<int[]>();
            using (TextReader reader = new StreamReader(path))
            {
                string line = reader.ReadLine();
                bool read = false;

                while(line != null)
                {
                    if(read)
                    {
                        string[] rowElements = line.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        layout.Add(rowElements.Select(x => int.Parse(x)).ToArray());
                    }

                    if (line.CompareTo("data=") == 0)
                    {
                        read = true;
                    }
                    else if (Regex.IsMatch(line, @"\bwidth=\d+"))
                    {
                        var regexSplit = Regex.Split(line, @"width=");
                        foreach (var item in regexSplit)
                        {
                            if (item != null && item != string.Empty)
                            {
                                width = int.Parse(item);
                            }
                        }
                    }
                    else if (Regex.IsMatch(line, @"\bheight=\d+"))
                    {
                        var regexSplit = Regex.Split(line, @"height=");
                        foreach (var item in regexSplit)
                        {
                            if (item != null && item != string.Empty)
                            {
                                height = int.Parse(item);
                            }
                        }
                    }

                    line = reader.ReadLine();
                }
            }

            int[,] result = new int[width, height];

            for (int row = 0; row < width; row++)
            {
                for (int col = 0; col < height; col++)
                {
                    result[row, col] = layout[row][col];
                }
            }

            return result;
        }
    }
}
