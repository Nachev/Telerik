namespace CardWars
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    class CardWars
    {
        static void Main()
        {
            Dictionary<string, int> ruleDict = new Dictionary<string, int>()
            {
            {"2", 10}, {"3", 9}, {"4", 8}, {"5", 7}, {"6", 6}, {"7", 5}, {"8", 4},
            {"9", 3}, {"10", 2}, {"A", 1}, {"J", 11}, {"Q", 12}, {"K", 13}
            };
            int numberN = int.Parse(Console.ReadLine());
            BigInteger firstPlFinalScores = new BigInteger();
            int firstPlGamesWon = new int();

            BigInteger secondPlFinalScores = new BigInteger();
            int secondPlGamesWon = new int();
            while (numberN > 0)
            {
                bool firstPlX = new bool();
                int firstPlTempScores = new int();
                for (int i = 0; i < 3; i++)
                {
                    string firstPlIn = Console.ReadLine();
                    if (firstPlIn == "X")
                    {
                        firstPlX = true; // Saves if X card has been drawed
                    }
                    else if (firstPlIn == "Z")
                    {
                        firstPlFinalScores *= 2; // Doubles player scores
                    }
                    else if (firstPlIn == "Y")
                    {
                        firstPlFinalScores -= 200;
                    }
                    else
                    {
                        firstPlTempScores += ruleDict[firstPlIn];
                    }
                }

                bool secondPlX = new bool();
                int secondPlTempScores = new int();
                for (int i = 0; i < 3; i++)
                {
                    string secondPlIn = Console.ReadLine();
                    if (secondPlIn == "X")
                    {
                        secondPlX = true;
                    }
                    else if (secondPlIn == "Z")
                    {
                        secondPlFinalScores *= 2;
                    }
                    else if (secondPlIn == "Y")
                    {
                        secondPlFinalScores -= 200;
                    }
                    else
                    {
                        secondPlTempScores += ruleDict[secondPlIn];
                    }
                }

                if (firstPlX && secondPlX)
                {
                    firstPlFinalScores += 50;
                    secondPlFinalScores += 50;
                }
                else if (firstPlX)
                {
                    Console.WriteLine("X card drawn! Player one wins the match!");
                    return;
                }
                else if (secondPlX)
                {
                    Console.WriteLine("X card drawn! Player two wins the match!");
                    return;
                }

                if (firstPlTempScores > secondPlTempScores)
                {
                    firstPlFinalScores += firstPlTempScores;
                    firstPlGamesWon++;
                }
                else if (firstPlTempScores < secondPlTempScores)
                {
                    secondPlFinalScores += secondPlTempScores;
                    secondPlGamesWon++;
                }

                numberN--;
            }

            if (firstPlFinalScores > secondPlFinalScores)
            {
                Console.WriteLine("First player wins!");
                Console.WriteLine("Score: {0}", firstPlFinalScores);
                Console.WriteLine("Games won: {0}", firstPlGamesWon);
            }
            else if (firstPlFinalScores < secondPlFinalScores)
            {
                Console.WriteLine("Second player wins!");
                Console.WriteLine("Score: {0}", secondPlFinalScores);
                Console.WriteLine("Games won: {0}", secondPlGamesWon);
            }
            else
            {
                Console.WriteLine("It's a tie!");
                Console.WriteLine("Score: {0}", firstPlFinalScores);
            }

        }
    }
}
