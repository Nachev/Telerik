namespace XTankWarsLibrary
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using XTankWarsLibrary.TileEngine;

    public static class TxtMapReader
    {
        #region Fields
        private static int width;
        private static int height;
        private static int lastMaxValue = 0;
        #endregion

        public static Tile[,] Load(string path, int layerNumber)
        {
            List<int[]> layout = new List<int[]>();
            using (TextReader reader = new StreamReader(path))
            {
                string line = reader.ReadLine();
                bool read = false;
                bool triggerFound = false;

                while (line != null)
                {
                    if (read)
                    {
                        if (line == string.Empty)
                        {
                            read = false;
                            break;
                        }

                        string[] rowElements = line.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        layout.Add(rowElements.Select(x => int.Parse(x) - lastMaxValue).ToArray());
                    }

                    if (triggerFound && line.CompareTo("data=") == 0)
                    {
                        read = true;
                        triggerFound = false;
                    }

                    if (line.CompareTo("type=Tile Layer " + layerNumber) == 0)
                    {
                        triggerFound = true;
                    }
                    else if (Regex.IsMatch(line, @"\bwidth=\d+"))
                    {
                        width = FindDimension(line, @"width=");
                    }
                    else if (Regex.IsMatch(line, @"\bheight=\d+"))
                    {
                        height = FindDimension(line, @"height=");
                    }

                    line = reader.ReadLine();
                }
            }

            Tile[,] result = new Tile[width, height];

            ConvertMatrix(result, layout, layerNumber);

            return result;
        }
  
        private static int FindDimension(string line, string regex)
        {
            var regexSplit = Regex.Split(line, regex);
            foreach (var item in regexSplit)
            {
                if (item != null && item != string.Empty)
                {
                    return int.Parse(item);
                }
            }

            return -1;
        }
  
        private static void ConvertMatrix(Tile[,] result, List<int[]> layout, int layerNumber)
        {
            int newMaxValue = int.MinValue;
            for (int row = 0; row < width; row++)
            {
                for (int col = 0; col < height; col++)
                {
                    result[row, col] = new Tile(layerNumber - 1, layout[row][col] - 1);

                    if (layout[row][col] > newMaxValue)
                    {
                        newMaxValue = layout[row][col];
                    }
                }
            }

            lastMaxValue += newMaxValue;
        }
    }
}
