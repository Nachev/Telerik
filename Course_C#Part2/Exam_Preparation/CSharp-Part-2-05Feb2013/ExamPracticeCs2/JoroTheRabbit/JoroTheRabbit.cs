namespace JoroTheRabbit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class JoroTheRabbit
    {
        private static void Main()
        {
            // Array input
            int[] playField = ArrayInput();
            int maxCounter = new int();

            // Every starting position
            for (int startingPosition = 0; startingPosition < playField.Length; startingPosition++)
            {
                // Every different step
                for (int step = 1; step < playField.Length; step++)
                {
                    int currentIndex = startingPosition;
                    int counter = 1;
                    int jumpDistance = (startingPosition + step) % playField.Length;
                    // Every jump
                    while (playField[jumpDistance] > playField[currentIndex]) 
                    {
                        counter++;
                        currentIndex = jumpDistance;
                        jumpDistance = (jumpDistance + step) % playField.Length;
                    }

                    if (counter > maxCounter)
                    {
                        maxCounter = counter;
                    }
                }
            }

            Console.WriteLine(maxCounter);
        }

        private static int[] ArrayInput()
        {
            string inputStr = Console.ReadLine();
            string[] splittedInput = inputStr.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            int[] input = new int[splittedInput.Length];

            for (int index = 0; index < input.Length; index++ )
            {
                input[index] = int.Parse(splittedInput[index]);
            }

            return input;
        }
    }
}
