namespace Laser
{
    using System;
    
    public class Laser
    {
        private static void Main()
        {
            int[] dimensions = InputLine();
            bool[, ,] cuboid = new bool[dimensions[0], dimensions[1], dimensions[2]];
            int[] masterCube = InputLine(1);

            BurnCurrentCube(cuboid, masterCube);

            int[] direction = InputLine();

            while (true)
            {
                int newDimension = new int();
                if (IsOnEdge(cuboid, NextCube(masterCube, direction)) || cuboid[NextCube(masterCube, direction)[0], NextCube(masterCube, direction)[1], NextCube(masterCube, direction)[2]])
                {
                    break;
                }
                else if (IsOnWall(cuboid, NextCube(masterCube, direction), out newDimension))
                {
                    masterCube = NextCube(masterCube, direction);
                    BurnCurrentCube(cuboid, masterCube);
                    SwitchDirection(direction, newDimension);
                }
                else
                {
                    masterCube = NextCube(masterCube, direction);
                    BurnCurrentCube(cuboid, masterCube);
                }
            }

            Console.WriteLine("{0} {1} {2}", masterCube[0] + 1, masterCube[1] + 1, masterCube[2] + 1);
        }

        private static int[] SwitchDirection(int[] direction, int newDimension)
        {
            direction[newDimension] *= -1;
            return direction;
        }

        private static bool IsOnWall(bool[, ,] cuboid, int[] cube, out int newDimension)
        {
            for (int dimension = 0; dimension < 3; dimension++)
            {
                if (isMinOrMax(cube[dimension], cuboid.GetLength(dimension) - 1))
                {
                    newDimension = dimension;
                    return true;
                }
            }

            newDimension = -1;
            return false;
        }

        private static void BurnCurrentCube(bool[, ,] cuboid, int[] masterCube)
        {
            cuboid[masterCube[0], masterCube[1], masterCube[2]] = true;
        }

        private static int[] InputLine(int coef = 0)
        {
            string[] dimensions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] input = { int.Parse(dimensions[0]) - coef, int.Parse(dimensions[1]) - coef, int.Parse(dimensions[2]) - coef };
            return input;
        }

        private static int[] NextCube(int[] currentCube, int[] direction)
        {
            int[] nextCube = new int[3];
            nextCube[0] = currentCube[0] + direction[0];
            nextCube[1] = currentCube[1] + direction[1];
            nextCube[2] = currentCube[2] + direction[2];
            return nextCube;
        }

        private static bool IsOnEdge(bool[,,] cuboid, int[] cube)
        {
            int count = 0;
            for (int dimension = 0; dimension < 3; dimension++)
            {
                if (isMinOrMax(cube[dimension], cuboid.GetLength(dimension) - 1))
                {
                    count++;
                }
            }

            return count > 1 ? true : false;
        }

        private static bool isMinOrMax(int dimension, int max)
        {
            if (dimension == 0 || dimension == max)
            {
                return true;
            }

            return false;
        }

    }
}
