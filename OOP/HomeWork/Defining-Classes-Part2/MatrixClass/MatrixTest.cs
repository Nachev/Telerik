namespace MatrixClass
{
    using System;

    public class MatrixTest
    {
        public static void Main()
        {
            var test1 = new Matrix<int>(new[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            var test2 = new Matrix<int>(new[,] { { 9, 8, 7 }, { 6, 5, 4 }, { 3, 2, 1 } });
            //// var test2 = new Matrix<double>(new[,] { { 2.35, 3.5, 1 }, { 2.5, 6, 4.56 }, { 2.35, 9, 78 } });
            var result = test1 + test2;
            Console.WriteLine(result);
            Console.WriteLine(test1 * test2);
            Console.WriteLine(test2 - test1);
        }
    }
}
