namespace Pacman
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Maze
    {
        private const char EmptySpace = ' '; // - 0
        private const char UpLeftCorner = '┌'; // - 1
        private const char UpRigthCorner = '┐'; // - 2
        private const char LowLeftCorner = '└'; // - 3
        private const char LowRightCorner = '┘'; // - 4
        private const char VerticalWall = '│'; // - 5
        private const char HorizontalWall = '─'; // - 6
        private const char Filling = '#'; // - 7
        private const char Door = '_'; // - 8
        private const char InsidePrison = ' '; // - 9

        private string[,] matrix = 
        {
        { "┌", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "┐" }, 
        { "│", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "│", "│", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "│" }, 
        { "│", " ", "┌", "─", "─", "┐", " ", "┌", "─", "─", "─", "┐", " ", "│", "│", " ", "┌", "─", "─", "─", "┐", " ", "┌", "─", "─", "┐", " ", "│" },
        { "│", " ", "│", "#", "#", "│", " ", "│", "#", "#", "#", "│", " ", "│", "│", " ", "│", "#", "#", "#", "│", " ", "│", "#", "#", "│", " ", "│" }, 
        { "│", " ", "└", "─", "─", "┘", " ", "└", "─", "─", "─", "┘", " ", "└", "┘", " ", "└", "─", "─", "─", "┘", " ", "└", "─", "─", "┘", " ", "│" },
        { "│", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "│" },
        { "│", " ", "┌", "─", "─", "┐", " ", "┌", "┐", " ", "┌", "─", "─", "─", "─", "─", "─", "┐", " ", "┌", "┐", " ", "┌", "─", "─", "┐", " ", "│" },
        { "│", " ", "└", "─", "─", "┘", " ", "│", "│", " ", "└", "─", "─", "┐", "┌", "─", "─", "┘", " ", "│", "│", " ", "└", "─", "─", "┘", " ", "│" }, 
        { "│", " ", " ", " ", " ", " ", " ", "│", "│", " ", " ", " ", " ", "│", "│", " ", " ", " ", " ", "│", "│", " ", " ", " ", " ", " ", " ", "│" }, 
        { "└", "─", "─", "─", "─", "┐", " ", "│", "└", "─", "─", "┐", " ", "│", "│", " ", "┌", "─", "─", "┘", "│", " ", "┌", "─", "─", "─", "─", "┘" },
        { "│", "#", "#", "#", "#", "│", " ", "│", "┌", "─", "─", "┘", " ", "└", "┘", " ", "└", "─", "─", "┐", "│", " ", "│", "#", "#", "#", "#", "│" },
        { "│", "#", "#", "#", "#", "│", " ", "│", "│", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "│", "│", " ", "│", "#", "#", "#", "#", "│" },
        { "│", "#", "#", "#", "#", "│", " ", "│", "│", " ", "┌", "─", "─", " ", " ", "─", "─", "┐", " ", "│", "│", " ", "│", "#", "#", "#", "#", "│" },
        { "└", "─", "─", "─", "─", "┘", " ", "└", "┘", " ", "│", "%", "%", "%", "%", "%", "%", "│", " ", "└", "┘", " ", "└", "─", "─", "─", "─", "┘" },
        { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "│", "%", "%", "%", "%", "%", "%", "│", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
        { "┌", "─", "─", "─", "─", "┐", " ", "┌", "┐", " ", "│", "%", "%", "%", "%", "%", "%", "│", " ", "┌", "┐", " ", "┌", "─", "─", "─", "─", "┐" },
        { "│", "#", "#", "#", "#", "│", " ", "│", "│", " ", "└", "─", "─", "─", "─", "─", "─", "┘", " ", "│", "│", " ", "│", "#", "#", "#", "#", "│" },
        { "│", "#", "#", "#", "#", "│", " ", "│", "│", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "│", "│", " ", "│", "#", "#", "#", "#", "│" },
        { "│", "#", "#", "#", "#", "│", " ", "│", "│", " ", "┌", "─", "─", "─", "─", "─", "─", "┐", " ", "│", "│", " ", "│", "#", "#", "#", "#", "│" },
        { "┌", "─", "─", "─", "─", "┘", " ", "└", "┘", " ", "└", "─", "─", "┐", "┌", "─", "─", "┘", " ", "└", "┘", " ", "└", "─", "─", "─", "─", "┐" },
        { "│", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "│", "│", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "│" },
        { "│", " ", "┌", "─", "─", "┐", " ", "┌", "─", "─", "─", "┐", " ", "│", "│", " ", "┌", "─", "─", "─", "┐", " ", "┌", "─", "─", "┐", " ", "│" },
        { "│", " ", "└", "─", "┐", "│", " ", "└", "─", "─", "─", "┘", " ", "└", "┘", " ", "└", "─", "─", "─", "┘", " ", "│", "┌", "─", "┘", " ", "│" },
        { "│", " ", " ", " ", "│", "│", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "│", "│", " ", " ", " ", "│" },
        { "│", "─", "┐", " ", "│", "│", " ", "┌", "┐", " ", "┌", "─", "─", "─", "─", "─", "─", "┐", " ", "┌", "┐", " ", "│", "│", " ", "┌", "─", "│" },
        { "│", "─", "┘", " ", "└", "┘", " ", "│", "│", " ", "└", "─", "─", "┐", "┌", "─", "─", "┘", " ", "│", "│", " ", "└", "┘", " ", "└", "─", "│" },
        { "│", " ", " ", " ", " ", " ", " ", "│", "│", " ", " ", " ", " ", "│", "│", " ", " ", " ", " ", "│", "│", " ", " ", " ", " ", " ", " ", "│" },
        { "│", " ", "┌", "─", "─", "─", "─", "┘", "└", "─", "─", "┐", " ", "│", "│", " ", "┌", "─", "─", "┘", "└", "─", "─", "─", "─", "┐", " ", "│" },
        { "│", " ", "└", "─", "─", "─", "─", "─", "─", "─", "─", "┘", " ", "└", "┘", " ", "└", "─", "─", "─", "─", "─", "─", "─", "─", "┘", " ", "│" },
        { "│", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "│" },
        { "└", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "─", "┘" },
        };

        public string this[int rows, int cols]
        {
            get
            {
                return this.matrix[rows, cols];
            }
        }

        public string FieldGenerator()
        {
            StringBuilder maze = new StringBuilder();
            Dictionary<string, char> mazeForms = new Dictionary<string, char>();
            DictionaryGenrator(mazeForms);

            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    maze.Append(mazeForms[this.matrix[row, col]]);
                }

                maze.AppendLine();
            }

            return maze.ToString();
        }

        public string[,] MatrixGenerator()
        {
            string[,] maze = this.matrix;

            return maze;
        }
     
        public bool IsThereTunnel(int objectCoordX, int objectCoordY)
        {
            bool isThereEmptyCell = new bool();
            if (this.matrix.GetLength(1) <= objectCoordX || this.matrix.GetLength(0) <= objectCoordY || objectCoordX < 0 || objectCoordY < 0)
            {
                return isThereEmptyCell;
            }
            else if (this.matrix[objectCoordY, objectCoordX] == " ")
            {
                isThereEmptyCell = true;
            }

            return isThereEmptyCell;
        }

        public bool IsItPrison(int objectCoordX, int objectCoordY)
        {
            bool isThereEmptyCell = new bool();
            if (this.matrix.GetLength(1) <= objectCoordX || this.matrix.GetLength(0) <= objectCoordY || objectCoordX < 0 || objectCoordY < 0)
            {
                return isThereEmptyCell;
            }
            else if (this.matrix[objectCoordY, objectCoordX] == "%")
            {
                isThereEmptyCell = true;
            }

            return isThereEmptyCell;
        }

        private static void DictionaryGenrator(Dictionary<string, char> mazeForms)
        {
            mazeForms.Add(" ", EmptySpace);
            mazeForms.Add("┌", UpLeftCorner);
            mazeForms.Add("┐", UpRigthCorner);
            mazeForms.Add("└", LowLeftCorner);
            mazeForms.Add("┘", LowRightCorner);
            mazeForms.Add("│", VerticalWall);
            mazeForms.Add("─", HorizontalWall);
            mazeForms.Add("#", Filling);
            mazeForms.Add("_", Door);
            mazeForms.Add("%", InsidePrison);      
        }
    }
}
