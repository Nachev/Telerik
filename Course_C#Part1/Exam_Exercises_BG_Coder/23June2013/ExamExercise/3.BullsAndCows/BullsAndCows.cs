namespace BullsAndCows
{
    using System;
    using System.Text;

    public class BullsAndCows
    {
        private static void Main()
        {
            int secretNumber = new int();
            bool parse = int.TryParse(Console.ReadLine(), out secretNumber);
            int bulls = int.Parse(Console.ReadLine());
            int cows = int.Parse(Console.ReadLine());
            int[] secretDigitsArr = new int[4];
            StringBuilder result = new StringBuilder();

            // No cases 3b 1c; b + c > 4; 
            if ((bulls == 3 && cows == 1) || (bulls + cows > 4) || !parse || secretNumber <= 0)
            {
                Console.Write("No" + " ");
            }
            else if (bulls == 4)
            {
                Console.Write(secretNumber + " ");
            }
            else
            {
                // Every single digit in array for secret number
                for (int index = 0; index < 4; index++)
                {
                    secretDigitsArr[index] = secretNumber % 10;
                    secretNumber /= 10;
                }

                int bullsCount = new int();
                int cowsCount = new int();
                int[] secretDigitsArrCp = new int[4];

                // Cycle all possible guessNumbers
                for (int guessNumber = 1111; guessNumber <= 9999; guessNumber++)
                {
                    bool noZero = true; // zero flag
                    bullsCount = 0;
                    cowsCount = 0;
                    int guessNumberCopy = guessNumber;
                    int[] guessDigitsArr = new int[4];
                    for (int index = 0; index < 4; index++)
                    {
                        guessDigitsArr[index] = guessNumberCopy % 10;
                        guessNumberCopy /= 10;
                    }

                    // Check for zero in the guess number
                    if (guessDigitsArr[0] == 0 || guessDigitsArr[1] == 0 || guessDigitsArr[2] == 0 || guessDigitsArr[3] == 0)
                    {
                        noZero = false;
                        continue;
                    }

                    // Copy the secret array
                    for (int copyIndex = 0; copyIndex < secretDigitsArr.Length; copyIndex++)
                    {
                        secretDigitsArrCp[copyIndex] = secretDigitsArr[copyIndex];
                    }

                    // Check for BULLS and remove guess digit if necessary
                    for (int position = 0; position < 4; position++)
                    {
                        if (guessDigitsArr[position] == secretDigitsArrCp[position])
                        {
                            bullsCount++;
                            secretDigitsArrCp[position] = -1;
                            guessDigitsArr[position] = -3;
                        }
                    }

                    // Check for cows and remove guess digit if necessary
                    if (bullsCount == bulls)
                    {
                        for (int position = 0; position < 4; position++)
                        {
                            for (int arrayIndex = 0; arrayIndex < 4; arrayIndex++)
                            {
                                //// Check for cows
                                if (guessDigitsArr[position] == secretDigitsArrCp[arrayIndex])
                                {
                                    cowsCount++;
                                    secretDigitsArrCp[arrayIndex] = -2;
                                    guessDigitsArr[position] = -4;
                                }
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }

                    // Check if counted bulls and cows satisfies the requirements
                    if (bulls == bullsCount && cows == cowsCount && noZero)
                    {
                        result.Append(guessNumber).Append(" ");
                    }
                }

                // If there is something in the result print it else - No
                if (result.Length > 0)
                {
                    Console.Write(result.ToString());
                }
                else
                {
                    Console.Write("No");
                }
            }
        }
    }
}