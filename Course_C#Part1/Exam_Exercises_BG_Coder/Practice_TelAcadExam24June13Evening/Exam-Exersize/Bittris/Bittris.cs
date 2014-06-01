namespace Bittris
{
    using System;

    class Bittris
    {
        static void Main()
        {
            int gameLength = int.Parse(Console.ReadLine());
            const uint highBitsMask = 4294967040;
            const uint leftBar = 128;
            const uint rightBar = 1;
            uint[] rows = new uint[5];
            int activeRow = new int();
            bool scored = new bool();
            int scores = new int();
            uint highBits = new uint();
            int tempScores = new int();
            uint currentElement = new uint();
            uint lastElement = new uint();
            while (gameLength > 0)
            {
                string commandInput = null;
                if (gameLength % 4 == 0) // New number input
                {
                    activeRow = 4;
                    highBits = 0;
                    currentElement = 0;
                    lastElement = 0;
                    uint inputNumber = uint.Parse(Console.ReadLine());
                    highBits = highBitsMask & inputNumber;
                    currentElement = inputNumber ^ highBits;
                    rows[activeRow] = currentElement;
                    scored = false;
                }
                else
                {
                    commandInput = Console.ReadLine();
                }

                switch (commandInput)
                {
                    case "D": // down
                        {
                            break;
                        }
                    case "L": // left
                        {
                            if (scored || (currentElement & leftBar) > 0 || (((currentElement << 1) & (rows[activeRow] ^ currentElement)) > 0))
                            {
                                break;
                            }
                            else
                            {
                                lastElement = currentElement; // save current element
                                currentElement <<= 1;
                            }

                            break;
                        }
                    case "R": // right
                        {
                            if (scored || (currentElement & rightBar) == 1 || (((currentElement >> 1) & (rows[activeRow] ^ currentElement)) > 0))
                            {
                                break;
                            }
                            else
                            {
                                lastElement = currentElement; // save current element
                                currentElement >>= 1;
                            }

                            break;
                        }
                    default:
                        break;
                }


                if ((currentElement & rows[activeRow - 1]) == 0) // no collission
                {
                    if (lastElement > 0)
                    {
                        rows[activeRow] ^= lastElement;
                        lastElement = 0;
                    }
                    else
                    {
                        rows[activeRow] ^= currentElement;
                    }

                    rows[activeRow - 1] |= currentElement;
                }
                else // Landing
                {
                    if (!scored)
                    {
                        if (lastElement > 0)
                        {
                            rows[activeRow] ^= lastElement;
                            rows[activeRow] |= currentElement;
                            lastElement = 0;
                        }

                        tempScores = Scoring(highBits, tempScores, currentElement);

                        if (rows[activeRow] == 255)
                        {
                            tempScores *= 10;
                            rows = FullLine(rows, activeRow);
                        }

                        scored = true;
                        scores += tempScores;
                    }
                }

                activeRow--;

                if (activeRow == 0 && !scored)
                {
                    tempScores = Scoring(highBits, tempScores, currentElement);

                    if (rows[activeRow] == 255)
                    {
                        tempScores *= 10;
                        rows = FullLine(rows, activeRow);
                    }

                    scored = true;
                    scores += tempScores;
                }

                // End of game condition
                if (scored && rows[3] > 0)
                {
                    break;
                }

                // DrawResult(gameLength, rows, activeRow, scores);

                gameLength--;
            }

            Console.Write(scores);
        }

        private static void DrawResult(int gameLength, uint[] rows, int activeRow, int scores)
        {
            Console.Clear();
            for (int i = 4; i >= 0; i--)
            {
                Console.WriteLine(Convert.ToString(rows[i], 2).PadLeft(8, '0'));
            }
            Console.WriteLine("Scores: " + scores);
            Console.WriteLine("Game length: " + gameLength);
            Console.WriteLine("Active row: " + (activeRow + 1));
        }

        private static int Scoring(uint highBits, int tempScores, uint currentElement)
        {
            uint finalNumber = currentElement | highBits;
            // Scoring
            tempScores = 0;
            for (int counter = 0; counter < 32; counter++)
            {
                uint testMask = (uint)1 << counter; // Use of Right Bar for 1 - it's uint :)
                if (((finalNumber & testMask) >> counter) == 1)
                {
                    tempScores++;
                }
            }
            return tempScores;
        }

        private static uint[] FullLine(uint[] rows, int activeRow)
        {
            rows[activeRow] = 0;
            for (int i = activeRow; i < 4; i++)
            {
                if (rows[i] == 0)
                {
                    rows[i] = rows[i + 1];
                    rows[i + 1] = 0;
                }
            }

            return rows;
        }
    }
}
