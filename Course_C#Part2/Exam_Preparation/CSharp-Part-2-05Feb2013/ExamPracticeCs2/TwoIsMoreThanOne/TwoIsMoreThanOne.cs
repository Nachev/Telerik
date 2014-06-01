namespace TwoIsMoreThanOne
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TwoIsMoreThanOne
    {
        private static Dictionary<int, int> threeFive = new Dictionary<int, int>() { { 1, 3 }, { 2, 5 } };
        private static long[] range;
        private static int countResult;

        private static void Main()
        {
            range = FirstTaskInput();
            FirstTaskSolver();
            int[] list = SecondTaskListInput();
            int percentile = PercentileInput();
            SolveSecondTask(list, percentile);
        }

        private static void SolveSecondTask(int[] list, int percentile)
        {
            int length = list.Length;
            for (int i = 0; i < length; i++)
            {
                int counter = new int();
                foreach (var number in list)
                {
                    if (list[i] >= number)
                    {
                        counter++;
                    }
                }

                if (counter >= length * (percentile / 100D))
                {
                    Console.WriteLine(list[i]);
                    return;
                }
            }

            Console.WriteLine(list.Length - 1);
        }

        private static int PercentileInput()
        {
            return int.Parse(Console.ReadLine().Trim());
        }

        private static int[] SecondTaskListInput()
        {
            string input = Console.ReadLine();
            string[] inputArr = input.Split(new string[] { ",", ", " }, StringSplitOptions.RemoveEmptyEntries);
            int[] output = new int[inputArr.Length];
            for (int i = 0; i < inputArr.Length; i++)
            {
                output[i] = int.Parse(inputArr[i]);
            }

            SelectionSort(output);
            return output;
        }

        private static void SelectionSort(int[] inputArray)
        {
            // Sorting by "Selection sort" algorithm
            for (int extIndex = 0; extIndex < inputArray.Length - 1; extIndex++)
            {
                int minNumber = inputArray[extIndex];
                int indexSave = new int();
                bool isThereSmaller = new bool();

                // Internal cycle for finding smallest value
                for (int intIndex = extIndex + 1; intIndex < inputArray.Length; intIndex++)
                {
                    if (minNumber > inputArray[intIndex])
                    {
                        isThereSmaller = true;
                        minNumber = inputArray[intIndex];
                        indexSave = intIndex;
                    }
                }

                // Exchange places there is smaller number
                if (isThereSmaller)
                {
                    int changer = inputArray[extIndex];
                    inputArray[extIndex] = inputArray[indexSave];
                    inputArray[indexSave] = changer;
                }
            }
        }

        private static void FirstTaskSolver()
        {
            int digits = CountDigits(range[1]);
            for (int i = 1; i <= digits; i++)
            {
                Variations(i);
            }

            Console.WriteLine(countResult);
        }

        private static int CountDigits(long num)
        {
            int counter = new int();
            while (num > 0)
            {
                counter++;
                num /= 10;
            }

            return counter;
        }

        private static long[] FirstTaskInput()
        {
            string input = Console.ReadLine();
            string[] rangeStr = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            long[] range = { long.Parse(rangeStr[0]), long.Parse(rangeStr[1]) };
            return range;
        }

        public static bool IsItPalindrome(long[] num)
        {
            long[] result = new long[num.Length];
            for (int i = 0, j = num.Length - 1; i < num.Length; i++, j--)
            {
                if (num[i] != num[j])
                {
                    return false;
                }
            }

            return true;
        }

        private static void Variations(int sequenceLength)
        {
            long[] arr = new long[sequenceLength];

            // initialize array to 1
            arr = InitLoops(arr);

            // Solve problem
            CalcVariationsRecursive(0, arr, sequenceLength);
        }

        private static void CalcVariationsRecursive(long currentElement, long[] arr, long sequenceLength)
        {
            // End of recursion condition
            if (currentElement == sequenceLength)
            {
                if (IsItPalindrome(arr))
                {
                    if(CompareToRange(arr))
                    {
                        countResult++;
                    }
                }
                return;
            }

            // Counter calling recursive same method. 
            for (int counter = 1; counter <= 2; counter++)
            {
                arr[currentElement] = threeFive[counter];
                CalcVariationsRecursive(currentElement + 1, arr, sequenceLength);
            }
        }

        private static bool CompareToRange(long[] arr)
        {
            long temp = new long();
            for (int i = 0; i < arr.Length; i++)
            {
                temp += arr[i] * Power(10, i);
            }

            if (temp < range[0] || temp > range[1])
            {
                return false;
            }

            return true;
        }

        private static long Power(int number, int exponent)
        {
            if (exponent == 0)
            {
                return 1;
            }
            else if (exponent == 1)
            {
                return number;
            }

            long result = number;
            for (int count = 1; count < exponent; count++)
            {
                // Try-catch block for integer overflow
                try
                {
                    checked
                    {
                        result *= number;
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Overflow in Power method!!");
                    Environment.Exit(0);
                }
            }

            return result;
        }

        private static long[] InitLoops(long[] arr)
        {
            // Initialize array to 1
            for (int index = 0; index < arr.Length; index++)
            {
                arr[index] = 1;
            }

            return arr;
        }
    }
}
