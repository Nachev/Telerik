namespace MatrixClass
{
    using System;
    using System.Threading;

    public class Matrix_Use
    {
        private static void Main()
        {
            Matrix matrix1 = new Matrix(3, 3);
            matrix1.Randomize(0, 10);

            Console.WriteLine("First matrix");
            Console.WriteLine(matrix1.ToString());

            Thread.Sleep(150);

            Matrix matrix2 = new Matrix(3, 3);
            matrix2.Randomize(0, 10);

            Console.WriteLine("Second matrix");
            Console.WriteLine(matrix2.ToString());

            Matrix resultMatrix = matrix1 + matrix2;

            Console.WriteLine("Add");
            Console.WriteLine(resultMatrix.ToString());

            resultMatrix = matrix1 - matrix2;

            Console.WriteLine("Substract");
            Console.WriteLine(resultMatrix.ToString());

            resultMatrix = matrix1 * matrix2;

            Console.WriteLine("Multiply");
            Console.WriteLine(resultMatrix.ToString());
        }
    }
}
