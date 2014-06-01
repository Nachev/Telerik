using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

/** Implement the "Falling Rocks" game in the text console. 
A small dwarf stays at the bottom of the screen and can move left and right 
(by the arrows keys). A number of rocks of different sizes and forms constantly 
fall down and you need to avoid a crash.Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, 
- distributed with appropriate density. The dwarf is (O). 
Ensure a constant game speed by Thread.Sleep(150).
Implement collision detection and scoring system.
*/

// Struct for screen objects
public struct Objects
{
    public int Xcoord;
    public int Ycoord;
    public ConsoleColor Color;
    public string Symbol;
}

public class FallingRocks
{
    // Prints given integers on given position
    private static void PrintOnPosition(int x, int y, int number, ConsoleColor color)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(number);
    }

    // Prints strings on position
    private static void PrintStringOnPosition(int x, int y, string str, ConsoleColor color)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(str);
    }

    private static void PrintMenu(int playfield)
    {
        // Draw menu
        // Draw menu line separator
        for (int count = 0; count < Console.WindowHeight; count++)
        {
            PrintStringOnPosition(playfield, count, "|", ConsoleColor.White);
        }

        // Print lives sign
        PrintStringOnPosition(playfield + 2, 5, "LIVES", ConsoleColor.White);

        // Print scores sign
        PrintStringOnPosition(playfield + 2, 8, "SCORES", ConsoleColor.White);

        // Print level sign
        PrintStringOnPosition(playfield + 2, 11, "LEVEL", ConsoleColor.White);
    }

    private static void Main()
    {
        Console.BufferHeight = Console.WindowHeight = 20; // Field:Buffer cut.
        Console.BufferWidth = Console.WindowWidth = 40;
        int playfield = Console.WindowWidth - 10;
        int scores = 0;
        int level = 0;
        int speed = 150;
        byte lives = 5;

        // Initial dwarf creation - (0)
        string dwarfSymbol = "(0)";
        Objects dwarf = new Objects();
        {
            dwarf.Ycoord = Console.WindowHeight - 1;
            dwarf.Xcoord = (playfield / 2) - 1;
            dwarf.Color = ConsoleColor.White;
            dwarf.Symbol = dwarfSymbol;
        }

        //// Draw menu
        PrintMenu(playfield);

        // Define random generator variable
        Random randomGenerator = new Random();

        // Creation of list that stores all rocks
        List<Objects> rocks = new List<Objects>();

        // List array of console color names
        List<string> colorNames = new List<string>(ConsoleColor.GetNames(typeof(ConsoleColor)));
        colorNames.Remove("Black");
        colorNames.Remove("Red");
        colorNames.Remove("White");

        // Get colorNames length in int
        int numColors = colorNames.Count;

        // String array of rock symbols
        string[] rockSymbol = { "^", "@", "*", "&", "+", "%", "$", "#", "!", ".", ";", "\u2665" };

        // Get rock symbols length in int
        int numRockSymbols = rockSymbol.Length;

        while (true)
        {
            // Lower rock creation rate
            int densityLength = 13 - (level % 1000);
            if (densityLength <= 2)
            {
                densityLength = 2;
            }
            int density = randomGenerator.Next(1, densityLength);
            if (density < 6)
            {
                int densityRand = randomGenerator.Next(1, 11);
                switch (densityRand)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        {
                            density = 1;
                        }
                        break;
                    case 6:
                    case 7:
                    case 8:
                        {
                            density = 2;
                        }
                        break;
                    case 9:
                    case 10:
                        {
                            density = 3;
                        }
                        break;
                    default:
                        break;
                }

                // Creation of binary mask to store x coordinates for all rocks on current row
                int mask = new int();

                // Creation of more than one in a line rocks
                while (density > 0)
                {
                    // Random rock generator - ^, @, *, &, +, %, $, #, !, ., ;, 
                    string rockSelector = rockSymbol[randomGenerator.Next(numRockSymbols)];

                    // Make rock symbol long
                    StringBuilder currentRock = new StringBuilder();
                    int rockLength = new int();
                    if (rockSelector != "\u2665")
                    {
                        rockLength = randomGenerator.Next(1, 4);
                    }
                    else
                    {
                        rockLength = 1;
                    }

                    for (int curRockIndex = 0; curRockIndex < rockLength; curRockIndex++)
                    {
                        currentRock.Append(rockSelector);
                    }

                    // Get random ConsoleColor string
                    string colorName = colorNames[randomGenerator.Next(numColors)];

                    // Get ConsoleColor from string name
                    ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorName);

                    // New rock cration block
                    // Ensure that next rock will not overlap previous one
                    int newXcoord = randomGenerator.Next(0, playfield + 1 - currentRock.Length);

                    // Using binary mask 00011110000010000110000
                    int tempMask = new int();
                    int freeSpace = 3;
                    for (int index = newXcoord - freeSpace; index < newXcoord + currentRock.Length + freeSpace; index++)
                    {
                        if (index >= 0 && index <= playfield)
                        {
                            tempMask |= 536870912 >> index; // 536870912 means one on bit 30 - x = 0
                        }
                    }

                    // Check if there is a match in ones bits
                    if ((mask & tempMask) != 0)
                    {
                        continue;
                    }
                    else
                    {
                        mask |= tempMask;
                    }

                    if (rockSelector != "\u2665")
                    {
                        Objects newRock = new Objects();
                        {
                            newRock.Color = color;
                            newRock.Xcoord = newXcoord;
                            newRock.Ycoord = 0;
                            newRock.Symbol = currentRock.ToString();
                            rocks.Add(newRock);
                        }
                    }
                    else
                    {
                        Objects newRock = new Objects();
                        {
                            newRock.Color = ConsoleColor.Red;
                            newRock.Xcoord = newXcoord;
                            newRock.Ycoord = 0;
                            newRock.Symbol = rockSelector;
                            rocks.Add(newRock);
                        }
                    }

                    density--;
                }
            }

            // Draw dwarf
            PrintStringOnPosition(dwarf.Xcoord, dwarf.Ycoord, dwarf.Symbol, dwarf.Color);

            // Move dwarf
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey();

                // Keeps dwarf in borders while moving left and right
                if (keyPressed.Key == ConsoleKey.LeftArrow)
                {
                    if (dwarf.Xcoord - 1 >= 0)
                    {
                        // Remove old dwarf
                        PrintStringOnPosition(dwarf.Xcoord, dwarf.Ycoord, new string(' ', dwarf.Symbol.Length), ConsoleColor.Black);
                        dwarf.Xcoord = dwarf.Xcoord - 1;
                    }
                }
                else if (keyPressed.Key == ConsoleKey.RightArrow)
                {
                    if (dwarf.Xcoord + dwarf.Symbol.Length < playfield)
                    {
                        // Remove old dwarf
                        PrintStringOnPosition(dwarf.Xcoord, dwarf.Ycoord, " ", ConsoleColor.Black);
                        dwarf.Xcoord = dwarf.Xcoord + 1;
                    }
                }

                // Draw dwarf
                PrintStringOnPosition(dwarf.Xcoord, dwarf.Ycoord, dwarf.Symbol, dwarf.Color);
            }

            bool levelUp = new bool();

            // Move rocks
            List<Objects> newList = new List<Objects>();
            List<Objects> formerState = new List<Objects>();
            for (int count = 0; count < rocks.Count; count++)
            {
                Objects oldRock = rocks[count];
                Objects newRock = new Objects();
                {
                    newRock.Xcoord = oldRock.Xcoord;
                    newRock.Ycoord = oldRock.Ycoord + 1;
                    newRock.Color = oldRock.Color;
                    newRock.Symbol = oldRock.Symbol;
                }

                // Save former state of rocks to remove them from screen
                formerState.Add(oldRock);

                // If moved rock is inside playfield borders (top-bottom) add it to new list for drawing
                // else adds score if a rock reaches the end of playfield
                if (newRock.Ycoord < Console.WindowHeight)
                {
                    newList.Add(newRock);
                }
                else if (newRock.Ycoord == Console.WindowHeight) 
                {
                    scores += 10;

                    // Draw scores
                    PrintOnPosition(playfield + 2, 9, scores, ConsoleColor.White);
                    if (scores % 1000 == 0)
                    {
                        levelUp = true;
                    }
                }

                // Colission detection
                if (newRock.Ycoord == dwarf.Ycoord)
                {
                    bool rightEdge = newRock.Xcoord < (dwarf.Xcoord + dwarf.Symbol.Length);
                    bool leftEdge = (newRock.Xcoord + newRock.Symbol.Length) > dwarf.Xcoord;
                    if (leftEdge && rightEdge)
                    {
                        if (newRock.Symbol != "\u2665")
                        {
                            lives--;
                            newList.Clear();
                            rocks.Clear();
                            dwarf.Xcoord = (playfield / 2) - 1;
                            Console.Clear(); // Clear console

                            //// Draw menu
                            PrintMenu(playfield);
                        }
                        else
                        {
                            lives++;
                        }
                    }
                }
            }

            rocks = newList;

            // Draw lives
            PrintOnPosition(playfield + 2, 6, lives, ConsoleColor.White);

            // Draw level
            PrintOnPosition(playfield + 2, 12, level, ConsoleColor.White);

            // Draw scores
            PrintOnPosition(playfield + 2, 9, scores, ConsoleColor.White);

            // Clear old rocks
            foreach (var oldRock in formerState)
            {
                PrintStringOnPosition(oldRock.Xcoord, oldRock.Ycoord, new string(' ', oldRock.Symbol.Length), ConsoleColor.Black);
            }

            // Draw rocks
            foreach (Objects rock in rocks)
            {
                PrintStringOnPosition(rock.Xcoord, rock.Ycoord, rock.Symbol, rock.Color);
            }

            // End of game condition
            if (lives == 0)
            {
                string gameOver = "GAME OVER!!!";
                PrintStringOnPosition((playfield / 2) - (gameOver.Length / 2), Console.WindowHeight / 2, gameOver, ConsoleColor.Red);
                Console.ReadKey();
                return;
            }

            // Make it harder
            if (levelUp)
            {
                level++;
            }

            Thread.Sleep(speed); // Game speed
        }
    }
}
