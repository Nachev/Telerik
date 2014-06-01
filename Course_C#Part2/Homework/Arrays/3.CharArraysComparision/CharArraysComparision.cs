using System;

/*Write a program that compares two char arrays lexicographically (letter by letter).*/

public class CharArraysComparision
{
    public static void Main()
    {
        Console.Title = "Compare char arrays";

        // Input of both arrays
        char[] firstCharArray = { 'A', 'b', 'x', 'F' };
        char[] secondCharArray = { 'a', 'B', 'x', 'j', 'b', 'n' };

        int length = Math.Min(firstCharArray.Length, secondCharArray.Length);

        Console.WriteLine("First array : {0}", new string(firstCharArray));
        Console.WriteLine("Second array : {0}", new string(secondCharArray));

        for (int arrIndex = 0; arrIndex < length; arrIndex++)
        {
            if ((firstCharArray[arrIndex] - secondCharArray[arrIndex] == 'a' - 'A') || 
                (firstCharArray[arrIndex] - secondCharArray[arrIndex] == 'A' - 'a'))
            {
                Console.WriteLine("Symbols {0} are the same letter, but in different letter case", arrIndex + 1);
            }
            else if (firstCharArray[arrIndex] > secondCharArray[arrIndex])
            {
                Console.WriteLine("{0} has greater ASCII number", firstCharArray[arrIndex]);
            }
            else if (firstCharArray[arrIndex] < secondCharArray[arrIndex])
            {
                Console.WriteLine("{0} has greater ASCII number", secondCharArray[arrIndex]);
            }
            else
            {
                Console.WriteLine("Symbols {0} are equal", arrIndex + 1);
            }
        }

        int longerLength = Math.Max(firstCharArray.Length, secondCharArray.Length);

        if (firstCharArray.Length > secondCharArray.Length)
        {
            Console.WriteLine("Fisrt array has {0} more elements", longerLength - length);
        }
        else if (firstCharArray.Length < secondCharArray.Length)
        {
            Console.WriteLine("Second array has {0} more elements", longerLength - length);
        }
    }
}