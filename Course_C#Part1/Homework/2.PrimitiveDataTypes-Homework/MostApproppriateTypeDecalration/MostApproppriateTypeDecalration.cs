using System;

/*Declare five variables choosing for each of them the most 
 * appropriate of the types byte, sbyte, short, ushort, int, 
 * uint, long, ulong to represent the following values: 52130, -115, 4825932, 97, -10000.*/

class MostAppropriateType
{
    static void Main()
    {
        ushort firstValue = 52130;
        sbyte secondValue = -115;
        int thirdValue = 4825932;
        byte fourthValue = 97; 
        short fifthValue = -10000;
        Console.WriteLine("There are different types of data representation. Here are five of them:");
        Console.WriteLine("{0,8}".PadLeft(8) + " - ushort", firstValue);
        Console.WriteLine("{0,8}".PadLeft(8) + " - sbyte", secondValue);
        Console.WriteLine("{0,8}".PadLeft(8) + " - int", thirdValue);
        Console.WriteLine("{0,8}".PadLeft(8) + " - byte", fourthValue);
        Console.WriteLine("{0,8}".PadLeft(8) + " - short", fifthValue);
    }
}