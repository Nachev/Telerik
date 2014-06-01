using System;

//Write a program to read your age from the console and print how old you will be after 10 years

class PrintAgeAfter10Years
{
    static void Main()
    {
        Console.Write("What is your age: ");
        byte age = new byte();
        bool check = new bool();
        //cycle that checks for correct input
        do
        {
            string temp = Console.ReadLine();
            check = byte.TryParse(temp, out age);
            if (check && age > 0)
            {
                break;
            }
            else
            {
                Console.Write("Wrong input! Try again: ");
            }
        } while (true);
        if (age > 122)
        {
            Console.WriteLine("Wow!! You are oldest person on Earth ever known!");
        }
        Console.WriteLine("Your age is: {0}", age);
        age += 10;
        Console.WriteLine("After 10 years you will be {0} years old", age);
    }
}