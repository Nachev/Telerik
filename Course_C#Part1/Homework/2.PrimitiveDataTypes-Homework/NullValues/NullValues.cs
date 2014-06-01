namespace NullValues
{
    using System;
    /*Create a program that assigns null values to an integer and to double variables.
     * Try to print them on the console, try to add some values or the null literal to them and see the result.
    */
    class NullValues
    {
        static void Main()
        {
            int? intNull = null;
            double? doubleNull = null;
            Console.WriteLine("Raw NULL - {0} \t {1}", intNull, doubleNull);
            intNull += 14;
            doubleNull += 5;
            Console.WriteLine("Changed NULL - {0} \t {1}", intNull, doubleNull);
            intNull = 14;
            doubleNull = 5;
            Console.WriteLine("Changed - {0} \t {1}", intNull, doubleNull);
            //when adding NULL to <type>? the result is NULL nomather previous value
            intNull += null;
            doubleNull += null;
            Console.WriteLine("Added NULL to - int? -> {0} and double? -> {1}", intNull, doubleNull);
        }
    }
}
