namespace CardsFiftyTwoDeckPrint
{
    using System;
    using System.Text;

    /*Write a program that prints all possible cards from a standard deck of 52 cards (without jokers). 
     * The cards should be printed with their English names. Use nested for loops and switch-case*/

    public class CardsFiftyTwoDeckPrint
    {
        public static void Main()
        {
            // Creating string arrays for colors and figures
            string[] color = { "Clubs", "Diamonds", "Hearts", "Spades" };
            string[] figures = { "Jack", "Queen", "King", "Ace" };

            StringBuilder result = new StringBuilder();

            // External loop for colors
            for (int colorCount = 0; colorCount < 4; colorCount++)
            {
                // internal loop for figures
                for (int figureCount = 1; figureCount <= 13; figureCount++)
                {
                    switch (figureCount)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                            {
                                result.Append(figureCount + 1).Append(" of ").Append(color[colorCount]).Append(", ");
                                break;
                            }

                        case 10:
                        case 11:
                        case 12:
                        case 13:
                            {
                                result.Append(figures[figureCount - 10]).Append(" of ").Append(color[colorCount]).Append(", ");
                                break;
                            }

                        default:
                            break;
                    }

                    // Change line on every 4 cards
                    if (figureCount % 5 == 0)
                    {
                       result.AppendLine();
                    }
                }

                // Remove the last pause break
                result.Remove(result.Length - 2, 1);

                // Separate different colors
                result.AppendLine().AppendLine();
            }

            Console.WriteLine(result.ToString());
        }
    }
}
