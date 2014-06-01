namespace SortingStringArrBySize
{
    using System;
    using System.Text;

    /*You are given an array of strings. Write a method that sorts the array by the 
     * length of its elements (the number of characters composing them)*/

    public class SortingStringArrBySize
    {
        private static void Main()
        {
            Console.Title = "Sort string array by length";
            /*
            // Array length input
            int length = new int();
            length = PositiveInput(length);

            // Array input*/
            string[] strArr = 
            {
            "iu", "iu", "iu", "sdf", "dfdhkgaljkg", "airplane",  
            "dgo", "dog", "dog", "goliath", "goal", "test", 
            "new", "int", "double", "equal", "java", "matrix", 
            "new", "newbe", "news", "new", "nest", "statement",
            "bow", "strength", "fly", "word", "word", "word" 
            }; // new string[length];
            // strArr = ArrInput(length);

            // Sort the array
            strArr = Sort(strArr, strArr.Length);

            // Print array
            Print(strArr, strArr.Length);
        }

        private static int PositiveInput(int length)
        {
            int exitCount = 5;
            do
            {
                if (exitCount > 0)
                {
                    length = Input("array count");
                }
                else
                {
                    Environment.Exit(0);
                }

                exitCount--;
            }
            while (length < 1);

            return length;
        }

        private static int Input(string variable)
        {
            int value = new int();
            int breakCounter = 5;
            do
            {
                Console.Write("Enter value for {0}: ", variable);
                string temp = Console.ReadLine();

                if (int.TryParse(temp, out value))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input! Try again.");
                }

                breakCounter--;
            }
            while (breakCounter > 0);

            return value;
        }

        private static string[] ArrInput(int length)
        {
            string[] strArr = new string[length];

            for (int count = 0; count < length; count++)
            {
                Console.Write("Enter value for element {0} - ", count + 1);
                strArr[count] = Console.ReadLine();
            }

            return strArr;
        }

        private static string[] Sort(string[] arr, int length)
        {
            for (int count = 0; count < length; count++)
            {
                int value = arr[count].Length;
                string swap = arr[count];
                int index = count;

                while (index > 0 && arr[index - 1].Length >= value)
                {
                    arr[index] = arr[index - 1];
                    index--;
                }

                arr[index] = swap;
            }

            return arr;
        }

        private static void Print(string[] array, int length)
        {
            StringBuilder line = new StringBuilder();

            for (int index = 0; index < length; index++)
            {
                line.Append("element ").Append(index + 1).Append(" -> ");
                line.Append(array[index]).AppendLine();
            }

            Console.Write(line.ToString());
        }
    }
}
