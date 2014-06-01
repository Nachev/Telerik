namespace PermutationsOfSequence
{
    using System;
    using System.Collections.Generic;
    
    /*Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N]. 
     * Example: n = 3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}*/

    public class PermutationsOfSequence
    {
        private static void Main()
        {
            Console.Title = "Permutations";
            Console.WriteLine("Program that reads a number N and prints all the permutations of the numbers [1 … N]");
            List<int> arr = new List<int>();

            int seqLength = Input();

            // Fill in array with consecutive numbers from 1 to N
            for (int index = 1; index <= seqLength; index++)
            {
                arr.Add(index);
            }

            // Claculate N factorial - permutation count
            ulong permCount = 1L;
            ulong tempL = (ulong)seqLength;
            while (tempL > 0)
            {
                permCount *= tempL;
                tempL--;
            }

            Console.WriteLine("Number of permutations: {0}", permCount);

            Approval();

            // Call method to calculate permutations lexicographically
            LexPerm(arr, seqLength, permCount);
        }

        private static void Approval()
        {
            int breakCount = 5;
            do
            {
                Console.WriteLine("Do you whant to continue? Y / N");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Y)
                {
                    Console.WriteLine();
                    break;
                }
                else if (key.Key == ConsoleKey.N)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Wrong input! Y or N available only.");
                }

                breakCount--;

                if (breakCount <= 0)
                {
                    Console.WriteLine("Error limit reached! Exiting.");
                    Environment.Exit(0);
                }
            }
            while (true);
        }

        private static int Input()
        {
            // Input block with check for correct input for array length
            int breakCount = 5;
            int seqLength = new int(); // Sequence length
            do
            {
                Console.Write("Enter number N: ");
                if (int.TryParse(Console.ReadLine(), out seqLength))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!!! Try again.");
                }

                breakCount--;

                if (breakCount <= 0)
                {
                    Console.WriteLine("Error limit reached! Exiting.");
                    Environment.Exit(0);
                }
            }
            while (breakCount > 0);
            return seqLength;
        }

        /*http://www.nakov.com/pranka/additional-materials/1.3-Kombinatorni-konfiguracii.txt
         * Procedure LeksPerm; {Лексикографско пораждане на пермутации}
            Var I,J,Min: integer;
            Begin
            for N:= 0 to N do P[N]:=N;
            repeat
                Print; {извеждаме поредното решение на екрана}
                {търсим първото I отдясно-наляво, за което P[I] < P[I+1]}
                I:= N-1; while (P[I] > P[I+1]) and (I > 0) do Dec(I);
                if I = 0 then Break; {няма такова I --> край на алгоритъма}
                {разменяме местата на P[I] и P[J]; P[J]=min(P[I+1],...,P[N]), P[J]>P[I]}
                Min:= I+1;
                for J:= I+2 to N do
                if (P[J] < P[Min]) and (P[J] > P[I]) then Min := J;
                Swp:=P[I]; P[I]:=P[Min]; P[Min]:=Swp;
                {обръщаме последователността на P[I+1], P[I+2],...,P[N]}
                for J:= 1 to ((N-I) div 2) do
                begin Swp:=P[I+J]; P[I+J]:=P[N-J+1]; P[N-J+1]:=Swp; end;
            until false;
            End;*/

        private static void LexPerm(List<int> arr, int seqLength, ulong permCount)
        {
            int indexK = new int();
            int indexL = new int();
            int min = new int();
            int lastIndex = seqLength - 1; // last index
            while (permCount > 0)
            {
                // Call method to print array
                Print(arr);

                // Find the largest index k such that a[k] < a[k + 1]
                indexK = lastIndex - 1;
                while ((arr[indexK] > arr[indexK + 1]) && indexK > 0)
                {
                    indexK--;
                }

                // Find the largest index l such that a[k] < a[l].
                min = indexK + 1;
                for (indexL = lastIndex; indexL > 0; indexL--)
                {
                    if (arr[indexK] < arr[min] && arr[indexL] > arr[indexK])
                    {
                        // Swap the value of a[k] with one at a[l]
                        min = indexL;
                        arr[indexK] ^= arr[min];
                        arr[min] ^= arr[indexK];
                        arr[indexK] ^= arr[min];
                    }
                }

                // Reverse the sequence from a[k + 1] up to and including the final element a[n].
                for (indexL = 1; indexL < lastIndex - indexK; indexL++)
                {
                    int swap = arr[indexK + indexL];
                    arr[indexK + indexL] = arr[lastIndex - indexL + 1];
                    arr[lastIndex - indexL + 1] = swap;
                }

                permCount--;
            }
        }

        private static void Print(List<int> arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }   
}
