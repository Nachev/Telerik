namespace Tron3D
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class Tron3D
    {
        private static int[,] patternLeft = { { 0, 1, 0 }, { 1, 0, 0 }, { 0, -1, 0 }, { -1, 0, 0 } };
        private static int[,] patternRight = { { 0, 1, 0 }, { -1, 0, 0 }, { 0, -1, 0 }, { 1, 0, 0 } };
        private static int x = new int();
        private static int y = new int();
        private static int z = new int();

        private static void Main()
        {
            int[] dimensions = InputDimensions();
            x = dimensions[0];
            y = dimensions[1];
            z = dimensions[2];
            bool[, ,] cuboid = new bool[x, y, z];
            int[] redPlayer = { x / 2, 0, 0 };
            int[] bluePlayer = { x / 2, y, 0 };
            int[] directionRed = { 0, 1, 0 };
            int[] directionBlue = { 0, -1, 0 };
            string movementRed = Console.ReadLine();
            string movementBlue = Console.ReadLine();

            BurnCurrentCube(cuboid, redPlayer);
            BurnCurrentCube(cuboid, bluePlayer);


            while (true)
            {
                int newDimension = new int();
                if (IsOnEdge(cuboid, NextCoordinates(redPlayer, directionRed)) || cuboid[NextCoordinates(redPlayer, directionRed)[0], NextCoordinates(redPlayer, directionRed)[1], NextCoordinates(redPlayer, directionRed)[2]])
                {
                    break;
                }
                else if (IsOnWall(cuboid, NextCoordinates(redPlayer, directionRed), out newDimension))
                {
                    redPlayer = NextCoordinates(redPlayer, directionRed);
                    BurnCurrentCube(cuboid, redPlayer);
                    SwitchDirection(directionRed, newDimension);
                }
                else
                {
                    redPlayer = NextCoordinates(redPlayer, directionRed);
                    BurnCurrentCube(cuboid, redPlayer);
                }
            }

            Console.WriteLine("{0} {1} {2}", redPlayer[0] + 1, redPlayer[1] + 1, redPlayer[2] + 1);
        }

        private static void Move(int[] player, int[] directions, char nextMove)
        {
            switch (nextMove)
            {
                case 'M':
                case 'm':
                    break;
                case 'L':
                case 'l':
                    int wall = CheckWall(player);
                    SwitchDirection(directions, 2);
                    break;
                default:
                    break;
            }
        }

        private static int CheckWall(int[] player)
        {
            if (player[1] == 0)
            {
                return 4;
            }
            else if (player[1] == y - 1)
            {
                return 2;
            }
            else if (player[2] == 0)
            {
                return 1;
            }
            else if (player[2] == z - 1)
            {
                return 3;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
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

        private static void BurnCurrentCube(bool[, ,] cuboid, int[] player)
        {
            cuboid[player[0], player[1], player[2]] = true;
        }

        private static int[] InputDimensions()
        {
            string[] dimensions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] input = { int.Parse(dimensions[0]) + 1, int.Parse(dimensions[1]) + 1, int.Parse(dimensions[2]) + 1 };
            return input;
        }

        private static int[] NextCoordinates(int[] player, int[] direction)
        {
            int[] nextCube = new int[3];
            nextCube[0] = player[0] + direction[0];
            nextCube[1] = player[1] + direction[1];
            nextCube[2] = player[2] + direction[2];
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
