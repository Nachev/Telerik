using System;

/*Write a program that allocates array of 20 integers and initializes each element by its 
index multiplied by 5. Print the obtained array on the console.*/

public class ArrayInitializationMultiplied
{
    public static void Main()
    {
        Console.Title = "Array initialization";

        int[] array = new int[20];
        for (int index = 0; index < array.Length; index++)
        {
            array[index] = index * 5;
        }

        // Print array
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
    }
}