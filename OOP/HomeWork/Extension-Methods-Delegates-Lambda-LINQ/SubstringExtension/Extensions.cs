namespace ExtensionMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    public static class Extensions
    {
        /*Implement an extension method Substring(int index, int length) for the class StringBuilder that 
         * returns new StringBuilder and has the same functionality as Substring in the class String.
         ------------------------------------------------------------------------------------------------*/
        public static string Substring(this StringBuilder strBld, int index, int length)
        {
            return strBld.ToString().Substring(index, length);
        }

        // ------------------------------------------------------------------------------------------------

        /*Implement a set of extension methods for IEnumerable<T> that implement the 
         * following group functions: sum, product, min, max, average.
         --------------------------------------------------------------------------------------------------*/
        public static T Sum<T>(this IEnumerable<T> collection)
        {
            dynamic result = default(T);
            foreach (var member in collection)
            {
                result += member;
            }

            return (T)result;
        }

        public static T Product<T>(this IEnumerable<T> collection)
        {
            dynamic result = default(T);
            foreach (var member in collection)
            {
                result *= member;
            }

            return (T)result;
        }

        public static T Min<T>(this IEnumerable<T> collection) where T : IComparable
        {
            dynamic minimal = collection.First();
            foreach (var member in collection)
            {
                if (minimal > member)
                {
                    minimal = member;
                }
            }

            return (T)minimal;
        }

        public static T Max<T>(this IEnumerable<T> collection) where T : IComparable
        {
            dynamic maximal = collection.First();
            foreach (var member in collection)
            {
                if (maximal < member)
                {
                    maximal = member;
                }
            }

            return (T)maximal;
        }

        public static double Average<T>(this IEnumerable<T> collection)
        {
            dynamic result = collection.Sum();
            int count = new int();
            foreach (var member in collection)
            {
                count++;
            }

            return result / (double)count;
        }

        //---------------------------------------------------------------------
    }
}
