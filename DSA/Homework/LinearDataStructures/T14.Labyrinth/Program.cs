namespace T14.Labyrinth
{
    using System;
    using System.Collections.Generic;

    public struct Coordinates<T> where T : IComparable<T>
    {
        public T X, Y;

        public Coordinates(T p1, T p2)
        {
            this.X = p1;
            this.Y = p2;
        }

        public static Coordinates<T> operator +(Coordinates<T> first, Coordinates<T> second)
        {
            dynamic x1 = first.X, x2 = second.X, y1 = first.Y, y2 = second.Y;
            return new Coordinates<T>(x1 + x2, y1 + y2);
        }

        public override string ToString()
        {
            return $"x: {X}, y: {Y}";
        }
    }

    public class LabyrinthTask
    {
        private static readonly int[,] Labyrinth =
        {
            { 0, 0, 0, -1, 0, -1 },
            { 0, -1, 0, -1, 0, -1 },
            { 0, -2, -1, 0, -1, 0 },
            { 0, -1, 0, 0, 0, 0 },
            { 0, 0, 0, -1, -1, 0 },
            { 0, 0, 0, -1, 0, -1 }
        };

        private static readonly Coordinates<int>[] Directions = 
        {
            new Coordinates<int>(0, 1),
            new Coordinates<int>(1, 0),
            new Coordinates<int>(0, -1),
            new Coordinates<int>(-1, 0)
        };

        private static readonly IDictionary<int, char> LabyrinthMap = new Dictionary<int, char>
        {
            { -2, '*' },
            { -1, 'x' },
            { 0, 'u' }
        };

        public static void Main(string[] args)
        {
            Traverse(Labyrinth, new Coordinates<int>(2, 1), 0);
            Print(Labyrinth);
        }

        private static void Print(int[,] labyrinth)
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int k = 0; k < labyrinth.GetLength(1); k++)
                {
                    int cell = labyrinth[i, k];
                    if (LabyrinthMap.ContainsKey(cell))
                    {
                        Console.Write(" {0} |", LabyrinthMap[cell]);
                    }
                    else
                    {
                        Console.Write(" {0} |", cell);
                    }
                }

                Console.WriteLine();
            }
        }

        private static void Traverse(int[,] labyrinth, Coordinates<int> currentPosition, int count)
        {
            if (currentPosition.X < 0 || currentPosition.X >= labyrinth.GetLength(0) ||
                currentPosition.Y < 0 || currentPosition.Y >= labyrinth.GetLength(1))
            {
                return;
            }

            int currentCell = labyrinth[currentPosition.X, currentPosition.Y];
            if (count > 0 && (currentCell < 0 || (currentCell != 0 && currentCell < count)))
            {
                return;
            }

            if (currentCell > -1)
            {
                labyrinth[currentPosition.X, currentPosition.Y] = count;
            }

            for (int i = 0, directionsLength = Directions.Length; i < directionsLength; i++)
            {
                var nextPosition = currentPosition + Directions[i];
                Traverse(labyrinth, nextPosition, count + 1);
            }
       }
    }
}
