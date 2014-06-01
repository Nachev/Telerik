namespace IndexOfLettersInWord
{
    using System;
    using System.Collections.Generic;

    /*Write a program that creates an array containing all letters from the alphabet (A-Z). 
     * Read a word from the console and print the index of each of its letters in the array*/

    public class IndexOfLettersInWord
    {
        public static void Main()
        {
            string inputWord = string.Empty;

            inputWord = WordInput(inputWord);

            // Alphabet to char array
            char[] alphabet = new char[52];
            AlphabetArrayCreate(alphabet);

            // Print char array
            PrintArr(alphabet);

            Console.WriteLine();
            List<int> indexes = new List<int>();
            FindAccordance(inputWord, alphabet, indexes);

            // Print the result
            PrintResult(indexes);

            Console.WriteLine("If only capital letters needed");

            // Create alphabet array of chars
            char[] capLetters = new char[26];
            AlphabetArrayCreate(capLetters);
            
            // Print capital letters array
            PrintArr(capLetters);

            // Solve
            List<int> capIndexes = new List<int>();
            FindAccordanceCap(inputWord, capLetters, capIndexes);

            // Print result
            PrintResult(capIndexes);
        }

        private static void FindAccordanceCap(string inputWord, char[] capLetters, List<int> capIndexes)
        {
            for (int index = 0; index < inputWord.Length; index++)
            {
                for (int arrIndex = 0; arrIndex < capLetters.Length; arrIndex++)
                {
                    if (inputWord[index] == capLetters[arrIndex] || 
                        inputWord[index] == capLetters[arrIndex] + 'a' - 'A')
                    {
                        capIndexes.Add(arrIndex);
                    }
                }
            }
        }

        private static void FindAccordance(string inputWord, char[] alphabet, List<int> indexes)
        {
            for (int wordIndex = 0; wordIndex < inputWord.Length; wordIndex++)
            {
                for (int alphaIndex = 0; alphaIndex < alphabet.Length; alphaIndex++)
                {
                    if (inputWord[wordIndex] == alphabet[alphaIndex])
                    {
                        indexes.Add(alphaIndex);
                    }
                }
            }
        }

        private static void PrintResult(List<int> indexes)
        {
            Console.WriteLine();
            Console.WriteLine("Character indexes of entered word:");

            foreach (var item in indexes)
            {
                Console.Write("{0} ", item);
            }

            Console.WriteLine();
        }

        private static void PrintArr(char[] alphabet)
        {
            int length = alphabet.Length;
            for (int alphaIndex = 0; alphaIndex < length; alphaIndex++)
            {
                Console.Write(" {0,2} - {1} ", alphaIndex, alphabet[alphaIndex]);
                if (alphaIndex % 5 == 4)
                {
                    Console.WriteLine();
                }
            }
        }

        private static void AlphabetArrayCreate(char[] alphabet)
        {
            int length = alphabet.Length;
            for (int index = 0, count = 0; index < length; index++, count++)
            {
                char temp = (char)(count + 65);
                if (char.IsLetter(temp))
                {
                    alphabet[index] = temp;
                }
                else
                {
                    index--;
                }
            }
        }

        private static string WordInput(string inputWord)
        {
            // Input cycle with check for correct input
            int breakCount = 5;
            do
            {
                Console.Write("Enter test word: ");
                inputWord = Console.ReadLine();
                int correctInput = new int();

                // Check if every character is letter
                for (int index = 0; index < inputWord.Length; index++)
                {
                    if (char.IsLetter(inputWord[index]))
                    {
                        correctInput++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (correctInput == inputWord.Length)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input! Enter word only.");
                }

                breakCount--;

                if (breakCount == 0)
                {
                    Console.WriteLine("Error limit reached! Exiting.");
                    Environment.Exit(0);
                }
            }
            while (breakCount > 0);
            return inputWord;
        }
    }
}
