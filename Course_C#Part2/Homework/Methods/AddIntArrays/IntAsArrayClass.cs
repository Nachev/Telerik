namespace IntAsArray
{
    /// ...
    /// <summary>Represent an integer number as array.</summary>
    /// ...
    using System;
    using System.Text;

    /*Write a method that adds two positive integer numbers represented as arrays of digits 
     * (each array element arr[i] contains a digit; the last digit is kept in arr[0]). 
     * Each of the numbers that will be added could have up to 10 000 digits*/

    public class IntAsArray
    {
        private int[] intAsArray;

        public IntAsArray(int length = 100) // Constructor
        {
            this.intAsArray = new int[length];
        }

        public int Length // Property returning length of the internal array
        {
            get
            {
                return this.intAsArray.Length;
            }
        }

        public int this[int index] // Indexer
        {
            get
            {
                return this.intAsArray[index];
            }

            set
            {
                this.intAsArray[index] = value;
            }
        }

        public static IntAsArray operator +(IntAsArray firstIntAsArray, IntAsArray secondIntAsArray)
        {
            int longLenght = firstIntAsArray.Length; // Longer array length
            int shortLength = secondIntAsArray.Length; // Shorter array length

            if (longLenght > shortLength)
            {
                return CalcPlus(firstIntAsArray, secondIntAsArray);
            }
            else
            {
                return CalcPlus(secondIntAsArray, firstIntAsArray);
            }
        }

        public static IntAsArray operator *(IntAsArray arrayInt, int integerNumber)
        {
            return Multiply(arrayInt, integerNumber);
        }

        public static IntAsArray operator *(int integerNumber, IntAsArray arrayInt)
        {
            return Multiply(arrayInt, integerNumber);
        }

        public static IntAsArray operator *(IntAsArray firstArrayInt, IntAsArray secondArrayInt)
        {
            return MultiplyTwoIAA(firstArrayInt, secondArrayInt);
        }

        public void Randomize() // Randomizes array values
        {
            Random randomGenerator = new Random();
            int length = this.intAsArray.Length;
            for (int index = 0; index < length; index++)
            {
                this.intAsArray[index] = randomGenerator.Next(0, 10);
            }
        }

        public override string ToString() // Print array without leading zeroes
        {
            StringBuilder result = new StringBuilder();
            bool removeZeroes = true;
            int length = this.intAsArray.Length;
            for (int index = length - 1; index >= 0; index--)
            {
                if (removeZeroes && this.intAsArray[index] == 0)
                {
                    // Removes first zeroes from the resulting number
                    continue;
                }
                else
                {
                    result.Append(this.intAsArray[index]);
                    removeZeroes = false;
                }
            }

            return result.ToString();
        }

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
        }

        private static IntAsArray Multiply(IntAsArray arrayInt, int integerNumber)
        {
            int arrLength = arrayInt.Length;
            int digitsCount = integerNumber.ToString().Length;
            int lengthResult = arrLength + digitsCount;
            IntAsArray[] sumArray = new IntAsArray[digitsCount];
            int count = new int(); // Counts for each digit in the number
            while (integerNumber > 0)
            {
                sumArray[count] = new IntAsArray(lengthResult); // Create IntAsArray with needed length
                int integerDigit = integerNumber % 10; // Takes next digit of int number
                integerNumber /= 10;
                int remainder = new int(); // Keeps the remainder of sum of gigits
                int indexCount = new int();
                for (; indexCount < arrLength; indexCount++)
                {
                    int tempSum = (arrayInt[indexCount] * integerDigit) + remainder;
                    sumArray[count][indexCount + count] = tempSum % 10;  // indexCount + count moves array row left
                    remainder = tempSum / 10;
                }

                if (remainder > 0)
                {
                    sumArray[count][indexCount] = remainder;
                }

                count++;
            }

            IntAsArray result = new IntAsArray(lengthResult);
            for (int index = 0; index < digitsCount; index++)
            {
                result += sumArray[index];
            }

            return result;
        }

        private static IntAsArray CalcPlus(IntAsArray firstIntAsArray, IntAsArray secondIntAsArray)
        {
            int longLenght = firstIntAsArray.Length; // Longer array length
            int shortLength = secondIntAsArray.Length; // Shorter array length
            IntAsArray result = new IntAsArray(longLenght + 1);
            int remainder = new int(); // Keeps remainder from sums bigger than 9
            for (int index = 0; index < longLenght; index++)
            {
                // If the arrays have different length first add the sum of corresponding digits plus remainder
                if (index < shortLength)
                {
                    int temp = firstIntAsArray[index] + secondIntAsArray[index] + remainder;
                    result[index] = temp % 10;
                    temp /= 10;
                    remainder = temp;
                }
                else
                {
                    // If one of the arrays is longer add the remaining digits from it to the result array plus remainder
                    int temp = firstIntAsArray[index] + remainder; // Bigger in size array elements + remainder
                    result[index] = temp % 10;
                    temp /= 10; 
                    remainder = temp;
                }

                if (index == longLenght - 1 && remainder > 0)
                {
                    result[longLenght] = remainder;
                }
            }

            return result;
        }
    }
}
