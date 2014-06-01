namespace PacmanGame
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;

    /// <summary>
    /// PacMan main class.
    /// </summary>
    public class ConsoleManager
    {
        #region constants
        public const int StartWindowsHeight = 25;
        public const int StartWindowsWidth = 80;
        public const int WindowsHeight = 31;
        public const int WindowsWidth = 58;
        public const int MazeHeight = 30;
        public const int MazeWidth = 28;
        #endregion

        #region global variables
        private static string fileName = @"HallOfFame.pacman";
        private static string musicBeggining = @"Sounds\pacman_beginning.wav";
        private static string musicEating = @"Sounds\pacman_chomp.wav";
        private static string musicDeath = @"Sounds\pacman_death.wav";

        private static string elapsedTime = string.Empty;
        private static Stopwatch stopWatch = new Stopwatch();
        private static int lives = 5;
        private static int score = 0;
        private static int goldCount = 0;
        private static Random rand = new Random();
        private static Ghosts[] ghosts = new Ghosts[4];
        private static PacMan pacMan;
        private static Maze maze = new Maze();
        private static List<Gold> goldTokens = new List<Gold>();
        private static Cherry[] cherryTokens = new Cherry[4];
        private static bool withCherry = false;
        #endregion

        /// <summary>
        /// Main method.
        /// </summary>
        private static void Main()
        {
            int cherryTimer = 0;
            CheckSoundFiles();
            CheckHallOfFameFile();
            StartScreen();
            Console.SetWindowSize(WindowsWidth, WindowsHeight);
            GenerateMaze();
            GenerateGold();
            GenerateCherry();
            GeneratePacMan();
            GenerateGhosts();
            DrawScoreBoard();
            TimeSpan ts = stopWatch.Elapsed;
            do
            {
                if (withCherry)
                {
                    cherryTimer++;

                    if (cherryTimer == 40)
                    {
                        cherryTimer = 0;
                        withCherry = false;
                        pacMan.SetNormal();
                    }
                    else if (cherryTimer == 1)
                    {
                        pacMan.SetGhostEater();
                    }
                }

                stopWatch.Reset();
                stopWatch.Start();
                ManageScoreBoard();
                PacManMovementManager();
                GhostsMovementManager();
                Thread.Sleep(250);

                stopWatch.Stop();

                ts = ts + stopWatch.Elapsed;
                elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                if (goldCount == score)
                {
                    Console.Clear();
                    EndScreen();
                }
            }
            while (true);
        }

        /// <summary>
        /// Checks if sound files are available.
        /// </summary>
        private static void CheckSoundFiles()
        {
            if (!(File.Exists(musicBeggining) && File.Exists(musicEating) && File.Exists(musicDeath)))
            {
                Console.WriteLine("One or more sound files are not available! Game can not continue.");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Checks if text file for record is available and creates it if neccessary 
        /// </summary>
        private static void CheckHallOfFameFile()
        {
            if (!File.Exists(fileName))
            {
                using (StreamWriter sw = File.CreateText(fileName))
                {
                }
            }
        }

        /// <summary>
        /// Pints end screen
        /// </summary>
        private static void EndScreen()
        {
            Console.SetWindowSize(StartWindowsWidth, StartWindowsHeight + 10);
            Console.CursorVisible = false;

            DrawPacManLogo();

            Console.WriteLine();
            Console.WriteLine();

            string text = "YOU WON THE GAME!!!";
            Console.Write("\n{0}", new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("{0}", new string(' ', (Console.WindowWidth - text.Length) / 2));

            List<string> bestScores = new List<string>();

            try
            {
                StreamReader reader = new StreamReader(fileName);
                using (reader)
                {
                    string line = string.Empty;
                    while (line != null)
                    {
                        line = reader.ReadLine();

                        if (line != null)
                        {
                            int dashPosition = line.IndexOf("-");
                            string currentName = line.Substring(0, dashPosition);
                            string currentScore = line.Substring(dashPosition);
                            currentScore = currentScore.TrimStart('-', ' ');

                            if (bestScores.Count < 10)
                            {
                                bestScores.Add(currentScore + "-" + currentName);
                            }
                        }
                    }
                }

                Console.WriteLine();

                if (bestScores.Count < 10)
                {
                    text = "Congratulations - you have entered the Hall of Fame!!!!";
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("\n{0}", new string('=', (Console.WindowWidth - text.Length) / 2));
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(text);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("{0}", new string('=', (Console.WindowWidth - text.Length) / 2));

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("Enter your name: ");
                    string name = Console.ReadLine();

                    bestScores.Add(elapsedTime + "-" + name);
                }
                else
                {
                    for (int i = 0; i < bestScores.Count; i++)
                    {
                        int dashPosition = bestScores[i].IndexOf("-");
                        string currentScore = bestScores[i].Substring(0, dashPosition);
                        string currentName = bestScores[i].Substring(dashPosition);
                        currentScore = currentScore.TrimStart('-', ' ');

                        if (string.Compare(elapsedTime, currentScore) < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            text = "Congratulations - you have entered into Hall of Fame!!!!";
                            Console.Write("\n{0}", new string('=', (Console.WindowWidth - text.Length) / 2));
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(text);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("{0}", new string('=', (Console.WindowWidth - text.Length) / 2));

                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine();

                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("Enter your name: ");
                            string name = Console.ReadLine();

                            bestScores.Add(elapsedTime + "-" + name);
                            break;
                        }
                    }
                }

                bestScores.Sort();

                StreamWriter writer = new StreamWriter(fileName);
                using (writer)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (i < bestScores.Count)
                        {
                            int dashPosition = bestScores[i].IndexOf("-");
                            string currentScore = bestScores[i].Substring(0, dashPosition);
                            string currentName = bestScores[i].Substring(dashPosition);
                            currentName = currentName.TrimStart('-', ' ');
                            currentName = currentName.TrimEnd(' ');

                            writer.WriteLine(currentName + " - " + currentScore);
                        }
                    }
                }

                Console.WriteLine();

                text = "Hall of Fame";
                Console.Write("\n{0}", new string('=', (Console.WindowWidth - text.Length) / 2));
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(text);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("{0}", new string('=', (Console.WindowWidth - text.Length) / 2));

                reader = new StreamReader(fileName);
                using (reader)
                {
                    string line = string.Empty;
                    while (line != null)
                    {
                        line = reader.ReadLine();
                        if (line != null)
                        {
                            text = line;
                            Console.Write("\n{0}", new string(' ', (Console.WindowWidth - text.Length - 1) / 2));
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(text);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("{0}", new string(' ', (Console.WindowWidth - text.Length - 1) / 2));
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file doesn't exists");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The folder doesn't exists");
            }
            catch (DriveNotFoundException)
            {
                Console.WriteLine("The drive doesn't exists");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("The path to the file is too long");
            }
            catch (FileLoadException)
            {
                Console.WriteLine("Problem with loading the file");
            }
            catch (Exception)
            {
                Console.WriteLine("Unknown error");
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            while (keyInfo.Key != ConsoleKey.Spacebar)
            {
                keyInfo = Console.ReadKey(true);
            }

            Environment.Exit(1);
        }

        /// <summary>
        /// Draws PacMan logo on console
        /// </summary>
        private static void DrawPacManLogo()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  ooooooooo      ooo        ooooooo    ooooo     ooooo     ooo     oooo    ooo");
            Console.WriteLine("  oooooooooo    ooooo     ooooooooooo  oooooo   oooooo    ooooo    ooooo   ooo");
            Console.WriteLine("  ooo    oooo  ooooooo   ooooo   ooooo ooooooo ooooooo   ooooooo   oooooo  ooo");
            Console.WriteLine("  oooooooooo  ooo   ooo  oooo          ooooooooooooooo  ooo   ooo  ooooooo ooo");
            Console.WriteLine("  oooooooo   ooooooooooo oooo    ooooo oooo ooooo oooo ooooooooooo ooo  oooooo");
            Console.WriteLine("  ooo        ooooooooooo  ooooooooooo  oooo ooooo oooo ooooooooooo ooo   ooooo");
            Console.WriteLine("  ooo        ooo     ooo    ooooooo    oooo  ooo  oooo ooo     ooo ooo    oooo");
            Console.WriteLine();

            string message = "TEAM MERA'S VERSION";
            Console.Write("\n{0}", new string('=', (Console.WindowWidth - message.Length) / 2));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("{0}", new string('=', (Console.WindowWidth - message.Length) / 2));
        }

        /// <summary>
        /// Prints start screen
        /// </summary>
        private static void StartScreen()
        {
            System.Media.SoundPlayer startScreenMusic = new System.Media.SoundPlayer(musicBeggining);
            startScreenMusic.PlayLooping();
            Console.SetWindowSize(StartWindowsWidth, StartWindowsHeight);
            Console.CursorVisible = false;

            DrawPacManLogo();

            Console.WriteLine();
            Console.WriteLine();

            string text = "Instructions";
            Console.Write("\n{0}", new string('=', (Console.WindowWidth - text.Length) / 2));
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("{0}", new string('=', (Console.WindowWidth - text.Length) / 2));

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("To move use arrow keys. Avoid ghosts and collect all the gold as quickly as possible. You got 5 lives. If the ghosts catch you, you lose life. When all lifes are lost your game is over. If you succeed to get all the gold and your timing is good you will enter in Hall of fame :)");
            Console.WriteLine("Good luck!");

            text = "To start the game press Space";
            Console.WriteLine();
            Console.Write("{0}{1}{0}", new string(' ', (Console.WindowWidth - text.Length) / 2), text);

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            while (keyInfo.Key != ConsoleKey.Spacebar)
            {
                keyInfo = Console.ReadKey(true);
            }

            startScreenMusic.Stop();
            Console.Clear();
        }

        /// <summary>
        /// Manages movement of PacMan.
        /// </summary>
        private static void PacManMovementManager()
        {
            int nextCoordX = pacMan.PosX;
            int nextCoordY = pacMan.PosY;

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                if (keyPressed.Key == ConsoleKey.UpArrow)
                {
                    nextCoordY = pacMan.PosY - 1;
                    if (maze.IsThereTunnel(nextCoordX, nextCoordY))
                    {
                        PacManVsObjectsManager(nextCoordX, nextCoordY);
                        pacMan.Move(MoveDirection.Up);
                    }
                }

                if (keyPressed.Key == ConsoleKey.LeftArrow)
                {
                    nextCoordX = pacMan.PosX - 1;
                    if (maze.IsThereTunnel(nextCoordX, nextCoordY))
                    {
                        PacManVsObjectsManager(nextCoordX, nextCoordY);
                        pacMan.Move(MoveDirection.Left);
                    }
                }

                if (keyPressed.Key == ConsoleKey.DownArrow)
                {
                    nextCoordY = pacMan.PosY + 1;
                    if (maze.IsThereTunnel(nextCoordX, nextCoordY))
                    {
                        PacManVsObjectsManager(nextCoordX, nextCoordY);
                        pacMan.Move(MoveDirection.Down);
                    }
                }

                if (keyPressed.Key == ConsoleKey.RightArrow)
                {
                    nextCoordX = pacMan.PosX + 1;
                    if (maze.IsThereTunnel(nextCoordX, nextCoordY))
                    {
                        PacManVsObjectsManager(nextCoordX, nextCoordY);
                        pacMan.Move(MoveDirection.Right);
                    }
                }
            }
        }

        /// <summary>
        /// Manages impact situations between PacMan and objects.
        /// </summary>
        /// <param name="pacManCoordX">Next PacMan X coordinate.</param>
        /// <param name="pacManCoordY">Next PacMan Y coordinate.</param>
        private static void PacManVsObjectsManager(int pacManCoordX, int pacManCoordY)
        {
            PacManVsGold(pacManCoordX, pacManCoordY);
            PacManVsCherry(pacManCoordX, pacManCoordY);
            PacManVsGhost(pacManCoordX, pacManCoordY);
        }

        /// <summary>
        /// Check for impact situations PacMan-Ghost
        /// </summary>
        /// <param name="pacManCoordX">Next PacMan X coordinate.</param>
        /// <param name="pacManCoordY">Next PacMan Y coordinate.</param>
        private static void PacManVsGhost(int pacManCoordX, int pacManCoordY)
        {
            for (int count = 0; count < ghosts.Length; count++)
            {
                if (ghosts[count].IsThereObject(pacManCoordX, pacManCoordY))
                {
                    if (withCherry)
                    {
                        ResetCurrentGhost(count);
                    }
                    else
                    {
                        PacManGhostImpact(count);
                    }
                }
            }
        }

        /// <summary>
        /// Manages impact PacMan-Ghost.
        /// </summary>
        /// <param name="count">Number of ghost in array.</param>
        private static void PacManGhostImpact(int count)
        {
            if (lives > 0)
            {
                Lifetaker();
            }
            else
            {
                GameOverScreen();
            }
        }

        /// <summary>
        /// Check for impact situations PacMan-Cherry.
        /// </summary>
        /// <param name="pacManCoordX">Next PacMan X coordinate.</param>
        /// <param name="pacManCoordY">Next PacMan Y coordinate.</param>
        private static void PacManVsCherry(int pacManCoordX, int pacManCoordY)
        {
            for (int index = 0; index < cherryTokens.Length; index++)
            {
                if (cherryTokens[index].IsThereCherry(pacManCoordX, pacManCoordY))
                {
                    withCherry = true;
                }
            }
        }

        /// <summary>
        /// Check for impact situations PacMan-Gold.
        /// </summary>
        /// <param name="pacManCoordX">Next PacMan X coordinate.</param>
        /// <param name="pacManCoordY">Next PacMan Y coordinate.</param>
        private static void PacManVsGold(int pacManCoordX, int pacManCoordY)
        {
            for (int index = 0; index < goldTokens.Count; index++)
            {
                if (goldTokens[index].IsThereGold(pacManCoordX, pacManCoordY))
                {
                    EatGold(index);
                }
            }
        }

        /// <summary>
        /// Manages life lost of PacMan.
        /// </summary>
        private static void Lifetaker()
        {
            using (System.Media.SoundPlayer death = new System.Media.SoundPlayer(musicDeath))
            {
                death.Play();
            }

            lives -= 1;
            Restart();
        }

        /// <summary>
        /// Manages gold eating.
        /// </summary>
        /// <param name="index">Index of gold token in list.</param>
        private static void EatGold(int index)
        {
            using (System.Media.SoundPlayer eat = new System.Media.SoundPlayer(musicEating))
            {
                eat.Play();
            }

            score += 1;
            goldTokens[index].RemoveFromPosition();
            goldTokens.RemoveAt(index);
        }

        /// <summary>
        /// Restarts PacMan and Ghosts positions.
        /// </summary>
        private static void Restart()
        {
            Console.SetCursorPosition(pacMan.PosX, pacMan.PosY);
            Console.Write(' ');
            GeneratePacMan();
            RemoveAllOldGhosts();
            GenerateGhosts();
            Thread.Sleep(1000);
        }

        /// <summary>
        /// Removes ghosts from previous positions.
        /// </summary>
        private static void RemoveAllOldGhosts()
        {
            for (int i = 0; i < ghosts.Length; i++)
            {
                Console.SetCursorPosition(ghosts[i].PosX, ghosts[i].PosY);
                Console.Write(' ');
            }
        }

        /// <summary>
        /// First chase mode.
        /// </summary>
        /// <param name="ghostX">Ghost X coordinate.</param>
        /// <param name="ghostY">Ghost Y coordinate.</param>
        /// <param name="pacX">PacMan X coordinate.</param>
        /// <param name="pacY">PacMan Y coordinate.</param>
        /// <returns>Array of directions.</returns>
        private static MoveDirection[] Chase1(int ghostX, int ghostY, int pacX, int pacY)
        {
            int[] distancesSq = 
                                { 
                                ((ghostX - pacX) * (ghostX - pacX)) + ((ghostY + 1 - pacY) * (ghostY + 1 - pacY)),
                                ((ghostX - pacX) * (ghostX - pacX)) + ((ghostY - 1 - pacY) * (ghostY - 1 - pacY)),
                                ((ghostX + 1 - pacX) * (ghostX + 1 - pacX)) + ((ghostY - pacY) * (ghostY - pacY)),
                                ((ghostX - 1 - pacX) * (ghostX - 1 - pacX)) + ((ghostY - pacY) * (ghostY - pacY))
                                };
            var tupleList = new List<Tuple<int, MoveDirection>>
            {
                Tuple.Create(distancesSq[0], MoveDirection.Up),
                Tuple.Create(distancesSq[1], MoveDirection.Down),
                Tuple.Create(distancesSq[2], MoveDirection.Right),
                Tuple.Create(distancesSq[3], MoveDirection.Left)
            };
            tupleList.Sort();
            MoveDirection[] sorted = { tupleList[0].Item2, tupleList[1].Item2, tupleList[2].Item2, tupleList[3].Item2 };
            return sorted;
        }

        /// <summary>
        /// Second chase mode.
        /// </summary>
        /// <param name="ghostX">Ghost X coordinate.</param>
        /// <param name="ghostY">Ghost Y coordinate.</param>
        /// <param name="pacX">PacMan X coordinate.</param>
        /// <param name="pacY">PacMan Y coordinate.</param>
        /// <returns>Array of directions.</returns>
        private static MoveDirection[] Chase2(int ghostX, int ghostY, int pacX, int pacY)
        {
            switch (pacMan.GetDirection)
            {
                case MoveDirection.Up:
                    return Chase1(ghostX, ghostY, pacX, pacY + 4);
                case MoveDirection.Down:
                    return Chase1(ghostX, ghostY, pacX, pacY - 4);
                case MoveDirection.Right:
                    return Chase1(ghostX, ghostY, pacX + 4, pacY);
                case MoveDirection.Left:
                    return Chase1(ghostX, ghostY, pacX - 4, pacY);
                default:
                    break;
            }

            Console.WriteLine("error 302");
            return Chase1(ghostX, ghostY, pacX, pacY);
        }

        /// <summary>
        /// Third chase mode.
        /// </summary>
        /// <param name="ghostX">Ghost X coordinate.</param>
        /// <param name="ghostY">Ghost Y coordinate.</param>
        /// <param name="pacX">PacMan X coordinate.</param>
        /// <param name="pacY">PacMan Y coordinate.</param>
        /// <returns>Array of directions.</returns>
        private static MoveDirection[] Chase3(int ghostX, int ghostY, int pacX, int pacY)
        {
            pacX += pacX - ghostX;
            pacY += pacY - ghostY;
            return Chase1(ghostX, ghostY, pacX, pacY);
        }

        /// <summary>
        /// Fourth chase mode.
        /// </summary>
        /// <param name="ghostX">Ghost X coordinate.</param>
        /// <param name="ghostY">Ghost Y coordinate.</param>
        /// <param name="pacX">PacMan X coordinate.</param>
        /// <param name="pacY">PacMan Y coordinate.</param>
        /// <returns>Array of directions.</returns>
        private static MoveDirection[] Chase4(int ghostX, int ghostY, int pacX, int pacY)
        {
            if (Math.Abs(pacX - ghostX) + Math.Abs(pacY - ghostY) > 8)
            {
                return Chase1(ghostX, ghostY, pacX, pacY);
            }

            return Chase1(ghostX, ghostY, 15, 15);
        }

        /// <summary>
        /// Checks if there is ghost on specified position.
        /// </summary>
        /// <param name="xCoord">X coordinate.</param>
        /// <param name="yCoord">Y coordinate.</param>
        /// <returns>True if there is ghost.</returns>
        private static bool IsThereGhost(int xCoord, int yCoord)
        {
            foreach (Ghosts ghost in ghosts)
            {
                if (ghost.PosX == xCoord && ghost.PosY == yCoord)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Manages ghost movement.
        /// </summary>
        private static void GhostsMovementManager()
        {
            for (int count = 0; count < ghosts.Length; count++)
            {
                int ghostCoordX = ghosts[count].PosX;
                int ghostCoordY = ghosts[count].PosY;
                MoveDirection choice = MoveDirection.Right;
                MoveDirection[] moves = { MoveDirection.Right, MoveDirection.Left, MoveDirection.Up, MoveDirection.Down };
                moves = SwitchChaseMode(count, moves);

                choice = DirectionChooser(count, choice, moves);

                SwitchGhostMovementDirection(count, ghostCoordX, ghostCoordY, choice);
            }
        }

        /// <summary>
        /// Switches chase mode.
        /// </summary>
        /// <param name="count">Number of ghost in array.</param>
        /// <param name="moves">Array of directions.</param>
        /// <returns>Array of directions.</returns>
        private static MoveDirection[] SwitchChaseMode(int count, MoveDirection[] moves)
        {
            switch (count)
            {
                case 0:
                    moves = Chase1(ghosts[count].PosX, ghosts[count].PosY, pacMan.PosX, pacMan.PosY);
                    break;
                case 1:
                    moves = Chase2(ghosts[count].PosX, ghosts[count].PosY, pacMan.PosX, pacMan.PosY);
                    break;
                case 2:
                    moves = Chase3(ghosts[count].PosX, ghosts[count].PosY, pacMan.PosX, pacMan.PosY);
                    break;
                case 3:
                    moves = Chase4(ghosts[count].PosX, ghosts[count].PosY, pacMan.PosX, pacMan.PosY);
                    break;
                default:
                    break;
            }

            return moves;
        }

        /// <summary>
        /// Chooses direction of ghost movement.
        /// </summary>
        /// <param name="count">Number of ghost in array.</param>
        /// <param name="direction">Direction name.</param>
        /// <param name="moves">Array of direction names.</param>
        /// <returns>Direction name.</returns>
        private static MoveDirection DirectionChooser(int count, MoveDirection direction, MoveDirection[] moves)
        {
            var displacementDict = new Dictionary<MoveDirection, int[]>()
            {
                { MoveDirection.Down, new int[] { 0, -1 } },
                { MoveDirection.Up, new int[] { 0, 1 } },
                { MoveDirection.Right, new int[] { 1, 0 } },
                { MoveDirection.Left, new int[] { -1, 0 } }
            };
            var opposite = new Dictionary<MoveDirection, MoveDirection>()
            {
                { MoveDirection.Down, MoveDirection.Up },
                { MoveDirection.Up, MoveDirection.Down }, 
                { MoveDirection.Right, MoveDirection.Left }, 
                { MoveDirection.Left, MoveDirection.Right }
            };
            for (int index = 0; index < 4; index++)
            {
                int[] displacementCoord = displacementDict[moves[index]];
                int nextXcoord = ghosts[count].PosX + displacementCoord[0];
                int nextYcoord = ghosts[count].PosY + displacementCoord[1];
                bool isItTunnel = maze.IsThereTunnel(nextXcoord, nextYcoord);
                bool isItPrison = maze.IsItPrison(nextXcoord, nextYcoord);
                bool isRightDirection = moves[index] != opposite[ghosts[count].GetDirection];
                bool thereIsGhost = IsThereGhost(nextXcoord, nextYcoord);
                if ((isItTunnel || isItPrison) && isRightDirection)
                {
                    if (thereIsGhost)
                    {
                        continue;
                    }

                    direction = moves[index];
                    break;
                }
            }

            return direction;
        }

        /// <summary>
        /// Switches ghost movement direction by specified choice.
        /// </summary>
        /// <param name="count">Number of ghost in array.</param>
        /// <param name="ghostCoordX">Current X coordinate of ghost.</param>
        /// <param name="ghostCoordY">Current Y coordinate of ghost.</param>
        /// <param name="choice">Direction choice.</param>
        private static void SwitchGhostMovementDirection(int count, int ghostCoordX, int ghostCoordY, MoveDirection choice)
        {
            switch (choice)
            {
                case MoveDirection.Up:
                    ghostCoordX = ghosts[count].PosX;
                    ghostCoordY = ghosts[count].PosY + 1;
                    CheckForPacManBeforeGhostMovement(count, choice, ghostCoordX, ghostCoordY);
                    DrawTokenAfterGhost(ghostCoordX, ghostCoordY - 1);
                    DrawCherryAfterGhost(ghostCoordX, ghostCoordY - 1);
                    break;
                case MoveDirection.Down:
                    ghostCoordX = ghosts[count].PosX;
                    ghostCoordY = ghosts[count].PosY - 1;
                    CheckForPacManBeforeGhostMovement(count, choice, ghostCoordX, ghostCoordY);
                    DrawTokenAfterGhost(ghostCoordX, ghostCoordY + 1);
                    DrawCherryAfterGhost(ghostCoordX, ghostCoordY + 1);
                    break;
                case MoveDirection.Right:
                    ghostCoordX = ghosts[count].PosX + 1;
                    ghostCoordY = ghosts[count].PosY;
                    CheckForPacManBeforeGhostMovement(count, choice, ghostCoordX, ghostCoordY);
                    DrawTokenAfterGhost(ghostCoordX - 1, ghostCoordY);
                    DrawCherryAfterGhost(ghostCoordX - 1, ghostCoordY);
                    break;
                case MoveDirection.Left:
                    ghostCoordX = ghosts[count].PosX - 1;
                    ghostCoordY = ghosts[count].PosY;
                    CheckForPacManBeforeGhostMovement(count, choice, ghostCoordX, ghostCoordY);
                    DrawTokenAfterGhost(ghostCoordX + 1, ghostCoordY);
                    DrawCherryAfterGhost(ghostCoordX + 1, ghostCoordY);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Checks for PacMan before moving ghost.
        /// </summary>
        /// <param name="count">Number of ghost in array.</param>
        /// <param name="direction">Direction of ghost movement.</param>
        /// <param name="ghostCoordX">Current X coordinate of ghost</param>
        /// <param name="ghostCoordY">Current Y coordinate of ghost</param>
        private static void CheckForPacManBeforeGhostMovement(int count, MoveDirection direction, int ghostCoordX, int ghostCoordY)
        {
            if (pacMan.IsThereObject(ghostCoordX, ghostCoordY))
            {
                PacManGhostMeetingManager(count);
            }
            else
            {
                MoveCurrentGhost(count, direction, ghostCoordX, ghostCoordY);
            }
        }

        /// <summary>
        /// Menages situation of ghost - PacMan meeting.
        /// </summary>
        /// <param name="count">Number of ghost in array</param>
        private static void PacManGhostMeetingManager(int count)
        {
            if (withCherry)
            {
                ResetCurrentGhost(count);
            }
            else
            {
                PacManGhostImpact(count);
            }
        }

        /// <summary>
        /// Resets ghost position
        /// </summary>
        /// <param name="count">Number of ghost in array</param>
        private static void ResetCurrentGhost(int count)
        {
            ghosts[count].ResetPosition();
        }

        /// <summary>
        /// Manages ghost displacement 
        /// </summary>
        /// <param name="count">Number of ghost in array</param>
        /// <param name="direction">Direction of movement</param>
        /// <param name="ghostCoordX">Previous X coordinate of ghost</param>
        /// <param name="ghostCoordY">Previous Y coordinate of ghost</param>
        private static void MoveCurrentGhost(int count, MoveDirection direction, int ghostCoordX, int ghostCoordY)
        {
            ghosts[count].Move(direction);
        }

        /// <summary>
        /// Draws game over screen 
        /// </summary>
        private static void GameOverScreen()
        {
            Console.Clear();
            Console.SetWindowSize(StartWindowsWidth, StartWindowsHeight + 10);
            Console.CursorVisible = false;

            DrawPacManLogo();

            Console.WriteLine();
            Console.WriteLine();

            string text = "GAME OVER! Be better next time!";
            Console.Write("\n{0}", new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("{0}", new string(' ', (Console.WindowWidth - text.Length) / 2));

            Console.WriteLine();
            try
            {
                StreamReader reader = new StreamReader(fileName);
                text = "Hall of Fame";
                Console.Write("\n{0}", new string('=', (Console.WindowWidth - text.Length) / 2));
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(text);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("{0}", new string('=', (Console.WindowWidth - text.Length) / 2));

                reader = new StreamReader(fileName);
                using (reader)
                {
                    string line = string.Empty;
                    while (line != null)
                    {
                        line = reader.ReadLine();
                        if (line != null)
                        {
                            text = line;
                            Console.Write("\n{0}", new string(' ', (Console.WindowWidth - text.Length - 1) / 2));
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(text);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("{0}", new string(' ', (Console.WindowWidth - text.Length - 1) / 2));
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file doesn't exists");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The folder doesn't exists");
            }
            catch (DriveNotFoundException)
            {
                Console.WriteLine("The drive doesn't exists");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("The path to the file is too long");
            }
            catch (FileLoadException)
            {
                Console.WriteLine("Problem with loading the file");
            }
            catch (Exception)
            {
                Console.WriteLine("Unknown error");
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            while (keyInfo.Key != ConsoleKey.Spacebar)
            {
                keyInfo = Console.ReadKey(true);
            }

            Environment.Exit(1);
        }

        /// <summary>
        /// Draws gold after ghost had passed
        /// </summary>
        /// <param name="ghostCoordX">X coordinate of ghost</param>
        /// <param name="ghostCoordY">Y coordinate of ghost</param>
        private static void DrawTokenAfterGhost(int ghostCoordX, int ghostCoordY)
        {
            foreach (var token in goldTokens)
            {
                if (token.IsThereGold(ghostCoordX, ghostCoordY))
                {
                    token.DrawAtPosition();
                }
            }
        }

        /// <summary>
        /// Draws cherry after ghost had passed
        /// </summary>
        /// <param name="ghostCoordX">X coordinate of ghost</param>
        /// <param name="ghostCoordY">Y coordinate of ghost</param>
        private static void DrawCherryAfterGhost(int ghostCoordX, int ghostCoordY)
        {
            foreach (var cherry in cherryTokens)
            {
                if (cherry.IsThereCherry(ghostCoordX, ghostCoordY))
                {
                    cherry.DrawAtPosition();
                }
            }
        }

        /// <summary>
        /// Manages score board
        /// </summary>
        private static void ManageScoreBoard()
        {
            int positionY = 0;
            int positionX = WindowsWidth - 30;

            positionX++;
            positionY++;
            Console.SetCursorPosition(positionX, positionY);
            Console.WriteLine("Score: {0}/{1}", score, goldCount);
            positionY++;
            Console.SetCursorPosition(positionX, positionY);
            Console.WriteLine("Lives: {0}", lives);
            positionY++;
            Console.SetCursorPosition(positionX, positionY);
            Console.WriteLine("Time: {0}", elapsedTime);

            positionY += 2;
            Console.SetCursorPosition(positionX, positionY);
            string text = "Hall of fame";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("{0}{1}{0}", new string('-', (29 - text.Length) / 2), text);
            positionY++;

            try
            {
                StreamReader reader = new StreamReader(fileName);
                using (reader)
                {
                    int lineNumber = 0;
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        lineNumber++;
                        positionY++;
                        Console.SetCursorPosition(positionX, positionY);
                        Console.WriteLine(line);

                        line = reader.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file doesn't exists");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The folder doesn't exists");
            }
            catch (DriveNotFoundException)
            {
                Console.WriteLine("The drive doesn't exists");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("The path to the file is too long");
            }
            catch (FileLoadException)
            {
                Console.WriteLine("Problem with loading the file");
            }
            catch (Exception)
            {
                Console.WriteLine("Unknown error");
            }
        }

        /// <summary>
        /// Draws score board on console
        /// </summary>
        private static void DrawScoreBoard()
        {
            int positionY = 0;
            int positionX = WindowsWidth - 30;

            Console.SetCursorPosition(positionX, positionY);
            Console.Write("┌");

            for (int i = 29; i < WindowsWidth - 1; i++)
            {
                Console.SetCursorPosition(i, positionY);
                Console.Write("─");
            }

            for (int i = 29; i < WindowsWidth - 1; i++)
            {
                Console.SetCursorPosition(i, WindowsHeight - 1);
                Console.Write("─");
            }

            Console.SetCursorPosition(WindowsWidth - 1, positionY);
            Console.Write("┐");

            for (int i = 1; i < WindowsHeight - 1; i++)
            {
                Console.SetCursorPosition(positionX, i);
                Console.Write("│");
            }

            Console.SetCursorPosition(positionX, WindowsHeight - 1);
            Console.Write("└");

            for (int i = 1; i < WindowsHeight - 1; i++)
            {
                Console.SetCursorPosition(WindowsWidth - 1, i);
                Console.Write("│");
            }

            Console.SetCursorPosition(WindowsWidth - 1, WindowsHeight - 1);
            Console.Write("┘");
        }

        /// <summary>
        /// Generates ghost instances with position and color
        /// </summary>
        private static void GenerateGhosts()
        {
            int count = 0;
            do
            {
                int coordX = 12 + count;
                int coordY = 15;
                string[] colors = { "Red", "Blue", "Green", "Cyan" };
                if (maze.IsItPrison(coordX, coordY))
                {
                    ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colors[count]);
                    ghosts[count] = new Ghosts(coordX, coordY, color);
                    count++;
                    if (count == ghosts.Length)
                    {
                        break;
                    }
                }
            }
            while (true);
        }

        /// <summary>
        /// Creates new instance of PacMan
        /// </summary>
        private static void GeneratePacMan()
        {
            pacMan = new PacMan();
        }

        /// <summary>
        /// Generates gold on every tunnel of the maze
        /// </summary>
        private static void GenerateGold()
        {
            for (int cols = 0; cols < MazeHeight; cols++)
            {
                for (int rows = 1; rows < MazeWidth; rows++)
                {
                    if (maze.IsThereTunnel(rows, cols))
                    {
                        Gold newToken = new Gold(rows, cols);
                        goldTokens.Add(newToken);
                    }
                }
            }

            DrawGold();
        }

        /// <summary>
        /// Generates gold on constant places in the maze
        /// </summary>
        private static void GenerateCherry()
        {
            cherryTokens[0] = new Cherry(1, 1);
            cherryTokens[1] = new Cherry(1, MazeHeight - 1);
            cherryTokens[2] = new Cherry(MazeWidth - 2, 1);
            cherryTokens[3] = new Cherry(MazeWidth - 2, MazeHeight - 1);

            DrawCherry();
        }

        /// <summary>
        /// Draws cherry tokens on console
        /// </summary>
        private static void DrawCherry()
        {
            foreach (var token in cherryTokens)
            {
                token.DrawAtPosition();
            }
        }

        /// <summary>
        /// Draws gold on console
        /// </summary>
        private static void DrawGold()
        {
            foreach (var token in goldTokens)
            {
                token.DrawAtPosition();
                goldCount++;
            }
        }

        /// <summary>
        /// Generates maze
        /// </summary>
        private static void GenerateMaze()
        {
            maze.DrawMaze();
            Console.SetCursorPosition(0, 0);
        }
    }
}