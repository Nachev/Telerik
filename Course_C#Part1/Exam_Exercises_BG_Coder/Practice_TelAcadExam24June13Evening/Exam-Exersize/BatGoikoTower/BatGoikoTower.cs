namespace BatGoikoTower
{
    using System;
    using System.Text;

    class BatGoikoTower
    {
        static void Main()
        {
            int height = int.Parse(Console.ReadLine());
            int crossbeamLine = 1;
            int lastCross = 1;
            StringBuilder line = new StringBuilder();
            for (int row = height, crossCount = 1; row > 0; row--, crossCount++)
            {
                bool inside = new bool();
                bool crossbeam = new bool();
                for (int left = 0; left < height; left++)
                {
                    if (left == row - 1)
                    {
                        line.Append("/");
                        inside = true;
                    }
                    else if (!inside || !(crossCount - crossbeamLine == lastCross))
                    {
                        line.Append(".");
                    }
                    else
                    {
                        line.Append("-");
                    }
                }

                for (int right = height; right > 0; right--)
                {
                    if (right == row)
                    {
                        line.Append("\\");
                        inside = false;
                    }
                    else if (!inside || !(crossCount - crossbeamLine == lastCross))
                    {
                        line.Append(".");
                    }
                    else
                    {
                        line.Append("-");
                        crossbeam = true;
                    }
                }

                if (crossbeam)
                {
                    crossbeamLine++;
                    lastCross = crossCount;
                }

                Console.WriteLine(line);
                line.Clear();
            }
        }
    }
}
