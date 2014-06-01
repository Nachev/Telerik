using System;

//Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...

class PrintFirst10MembersOfSequence
{
    static void Main()
    {
        int sign = 1;
        for (int index = 2; index < 10; index++)
        {
            Console.Write(index*sign + ", ");
            sign *= (-1);
        }
    }
}
