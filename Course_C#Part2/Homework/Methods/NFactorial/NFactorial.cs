namespace NFactorial
{
    using System;
    using System.Threading; 
    using IntAsArray; // using this namespace for previously created class IntAsArray

    /*Write a program to calculate n! for each n in the range [1..100]. Hint: Implement first a method 
    that multiplies a number represented as array of digits by given integer number*/

    public class NFactorial
    {
        private static void Main()
        {
            Console.Title = "N factorial calculator";
            int numberN = IntInput("desired number N");
            IntAsArray result = new IntAsArray();
            result[0] = 1;
            while (numberN > 0)
            {
                result *= numberN;
                numberN--;
            }

            Console.WriteLine("The resulting factorial is :");
            Console.WriteLine(result);
        }

        private static int IntInput(string name)
        {
            int input = new int();
            int breakCount = 5;
            do
            {
                Console.WriteLine("Enter value for {0} : ", name);
                string temp = Console.ReadLine();
                bool isCorrect = int.TryParse(temp, out input);
                if (isCorrect && input > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input! Try again.");
                }

                breakCount--;

                if (breakCount <= 0)
                {
                    Console.WriteLine("Error limit reached! Exiting.");
                    Environment.Exit(0);
                }
            } 
            while (true);

            return input;
        }

        /* Following method is implemented in the class IntAsArray
        private static IntAsArray MultiplyTwoIAA(IntAsArray firstArrayInt, IntAsArray secondArrayInt)
        {
            int firstArrLength = firstArrayInt.Length;
            int secondArrLength = secondArrayInt.Length;
            int lengthResult = firstArrLength + secondArrLength;
            IntAsArray[] sumArray = new IntAsArray[secondArrLength];
            for (int count = 0; count < secondArrLength; count++)
            {
                sumArray[count] = new IntAsArray(lengthResult); // Create IntAsArray array with needed length
                int integerDigit = secondArrayInt[count]; // Takes next digit of int number
                int remainder = new int(); // Keeps the remainder of sum of gigits
                int indexCount = new int();
                for (; indexCount < firstArrLength; indexCount++)
                {
                    int tempSum = (firstArrayInt[indexCount] * integerDigit) + remainder;
                    sumArray[count][indexCount + count] = tempSum % 10;  // indexCount + count moves array row left
                    remainder = tempSum / 10;
                }

                if (remainder > 0)
                {
                    sumArray[count][indexCount + count] = remainder;
                }
            }

            IntAsArray result = new IntAsArray(lengthResult);
            for (int index = 0; index < secondArrLength; index++)
            {
                result += sumArray[index];
            }
        
            return result;
         }*/
    }
}
