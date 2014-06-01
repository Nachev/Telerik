namespace Bittris
{
    using System;

    class Bittris
    {
        static void Main()
        {
            int gameLength = int.Parse(Console.ReadLine());
            uint inputNumber = new uint();
            uint highBits = new uint();
            const uint highBitsMask = 4294967040;
            const uint leftBar = 128;
            const uint rightBar = 1;
            uint[] rows = new uint[5];
            int activeRow = new int();
            bool[] rowOccupied = new bool[4];
            bool scored = new bool();
            int scores = new int();
            int tempScores = new int();
            uint lastRow = new int();
            while (gameLength > 0)
            {
                string commandInput = null;
                if (gameLength % 4 == 0) // New number input
                {
                    activeRow = 4;
                    inputNumber = uint.Parse(Console.ReadLine());
                    highBits = highBitsMask & inputNumber;
                    rows[activeRow] = inputNumber ^ highBits;
                    if (scored && !rowOccupied[1])
                    {
                        scores += tempScores;
                    }

                    lastRow = rows[activeRow];
                    scored = false;
                }
                else
                {
                    if (!rowOccupied[activeRow])
                    {
                        commandInput = Console.ReadLine();
                    }
                    else
                    {
                        commandInput = Console.ReadLine();
                        commandInput = "Does't matter";
                    }
                }

                switch (commandInput)
                {
                    case "D": // down
                        {
                            break;
                        }
                    case "L": // left
                        {
                            if ((rows[activeRow] & leftBar) > 0)
                            {
                                break;
                            }
                            else
                            {
                                rows[activeRow] <<= 1;
                            }

                            break;
                        }
                    case "R": // right
                        {
                            if ((rows[activeRow] & rightBar) == 1)
                            {
                                break;
                            }
                            else
                            {
                                rows[activeRow] >>= 1;
                            }

                            break;
                        }
                    default:
                        break;
                }

                if (activeRow > 0 && rowOccupied[activeRow - 1])
                {
                    if (!rowOccupied[activeRow] && (rows[activeRow] & rows[activeRow - 1]) == 0) // no collission
                    {
                        rows[activeRow - 1] |= rows[activeRow]; // Merge two digits
                        lastRow = rows[activeRow];
                        rows[activeRow] ^= rows[activeRow]; // Clear previous line
                    }
                    else // Landing
                    {
                        if (!scored)
                        {
                            uint finalNumber = new uint();
                            finalNumber = lastRow | highBits;

                            // Scoring
                            tempScores = new int();
                            for (int counter = 0; counter < 32; counter++)
                            {
                                uint testMask = rightBar << counter; // Use of Right Bar for 1 - it's uint :)
                                if (((finalNumber & testMask) >> counter) == 1)
                                {
                                    tempScores++;
                                }
                            }

                            if (rows[activeRow] == 255)
                            {
                                rows[activeRow] = 0;
                                tempScores *= 10;
                            }
                            else
                            {
                                rowOccupied[activeRow] = true;
                            }

                            scores += tempScores;
                            scored = true;
                        }
                    }
                }
                else
                {
                    rows[activeRow - 1] |= rows[activeRow];
                    rows[activeRow] = 0;
                }

                // Check if first and only line is 11111111
                if (activeRow == 1 && rows[activeRow - 1] == 255)
                {
                    uint finalNumber = rows[activeRow] | highBits;
                    // Scoring
                    tempScores = new int();
                    for (int counter = 0; counter < 32; counter++)
                    {
                        uint testMask = rightBar << counter; // Use of Right Bar for 1 - it's uint :)
                        if (((finalNumber & testMask) >> counter) == 1)
                        {
                            tempScores++;
                        }
                    }

                    scored = true;
                    rows[activeRow - 1] = 0;
                    tempScores *= 10;
                }

                activeRow--;

                if (activeRow == 0 && rows[activeRow] > 0 && !rowOccupied[activeRow])
                {
                    uint finalNumber = rows[activeRow] | highBits;
                    // Scoring
                    tempScores = new int();
                    for (int counter = 0; counter < 32; counter++)
                    {
                        uint testMask = rightBar << counter; // Use of Right Bar for 1 - it's uint :)
                        if (((finalNumber & testMask) >> counter) == 1)
                        {
                            tempScores++;
                        }
                    }

                    scored = true;
                    rowOccupied[activeRow] = true;
                }

                if (rowOccupied[3])
                {
                    break;
                }

                Console.Clear();
                for (int i = 4; i >= 0; i--)
                {
                    Console.WriteLine(Convert.ToString(rows[i], 2).PadLeft(8, '0'));
                }
                Console.WriteLine("Scores: " + scores);

                gameLength--;
            }

            Console.Write(scores);
        }
    }
}
