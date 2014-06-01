namespace PacmanGame
{  
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    using Pacman;

    public class Program
    {
        // Константите и глобалните променливи
        public const int StartWindowsHeight = 25;
        public const int StartWindowsWidth = 80;
        public const int WindowsHeight = 31;
        public const int WindowsWidth = 58;
        public const int MazeHeight = 30;
        public const int MazeWidth = 28;

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

        private static void Main()
        {
            int cheryTimer = 0;
            CheckIfFileDontExist();
            StartScreen();
            Console.SetWindowSize(WindowsWidth, WindowsHeight);
            GenerateMaze();
            GenerateGold();
            GenerateCherry();
            GeneratePacMan();
            GenerateGhosts();
            TimeSpan ts = stopWatch.Elapsed;
            do
            {
                if (withCherry)
                {
                    cheryTimer++;
                    if (cheryTimer == 40)
                    {
                        cheryTimer = 0;
                        withCherry = false;
                        pacMan.Color = ConsoleColor.Yellow;
                    }
                    else
                    {
                        pacMan.Color = ConsoleColor.Red;       
                    }                  
                }
                stopWatch.Reset();
                stopWatch.Start();
                ScoreBoard();
                MovePacMan();
                
                MoveGhosts();
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

        private static void CheckIfFileDontExist()
        {
            if (!File.Exists(fileName))
            {
                using (StreamWriter sw = File.CreateText(fileName))
                {
                }
            } 
        }

        static void EndScreen()
        {
            Console.SetWindowSize(StartWindowsWidth, StartWindowsHeight + 10);
            Console.CursorVisible = false;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  ooooooooo      ooo        ooooooo    ooooo     ooooo     ooo     oooo    ooo");
            Console.WriteLine("  oooooooooo    ooooo     ooooooooooo  oooooo   oooooo    ooooo    ooooo   ooo");
            Console.WriteLine("  ooo    oooo  ooooooo   ooooo   ooooo ooooooo ooooooo   ooooooo   oooooo  ooo");
            Console.WriteLine("  oooooooooo  ooo   ooo  oooo          ooooooooooooooo  ooo   ooo  ooooooo ooo");
            Console.WriteLine("  oooooooo   ooooooooooo oooo    ooooo oooo ooooo oooo ooooooooooo ooo  oooooo");
            Console.WriteLine("  ooo        ooooooooooo  ooooooooooo  oooo ooooo oooo ooooooooooo ooo   ooooo");
            Console.WriteLine("  ooo        ooo     ooo    ooooooo    oooo  ooo  oooo ooo     ooo ooo    oooo");
            Console.WriteLine();

            string text = "TEAM MERA'S VERSION";
            Console.Write("\n{0}", new string('=', (Console.WindowWidth - text.Length) / 2));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("{0}", new string('=', (Console.WindowWidth - text.Length) / 2));

            Console.WriteLine();
            Console.WriteLine();

            text = "YOU WON THE GAME!!!";
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

        static void StartScreen()
        {
            System.Media.SoundPlayer startScreenMusic = new System.Media.SoundPlayer(musicBeggining);
            startScreenMusic.PlayLooping();
            Console.SetWindowSize(StartWindowsWidth, StartWindowsHeight);
            Console.CursorVisible = false;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  ooooooooo      ooo        ooooooo    ooooo     ooooo     ooo     oooo    ooo");
            Console.WriteLine("  oooooooooo    ooooo     ooooooooooo  oooooo   oooooo    ooooo    ooooo   ooo");
            Console.WriteLine("  ooo    oooo  ooooooo   ooooo   ooooo ooooooo ooooooo   ooooooo   oooooo  ooo");
            Console.WriteLine("  oooooooooo  ooo   ooo  oooo          ooooooooooooooo  ooo   ooo  ooooooo ooo");
            Console.WriteLine("  oooooooo   ooooooooooo oooo    ooooo oooo ooooo oooo ooooooooooo ooo  oooooo");
            Console.WriteLine("  ooo        ooooooooooo  ooooooooooo  oooo ooooo oooo ooooooooooo ooo   ooooo");
            Console.WriteLine("  ooo        ooo     ooo    ooooooo    oooo  ooo  oooo ooo     ooo ooo    oooo");
            Console.WriteLine();

            string text = "TEAM MERA'S VESION"; 
            Console.Write("\n{0}", new string('=', (Console.WindowWidth - text.Length) / 2));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("{0}", new string('=', (Console.WindowWidth - text.Length) / 2));

            Console.WriteLine();
            Console.WriteLine();

            text = "Instructions";
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

        private static void MovePacMan()
        {
            /* Метода за движение на ПакМен-а. Първо вземаме текущото му положение
             * След това в зависимост от натисната стрелка проверяваме в тази
             * посока дали има стена. Ако има - не правим нищо. Но ако няма се прави
             * проверка дали има А)Злато Б)Дух. Ако има злато се вдига резултата с 1
             * Ако има Дух - GameOver :)
             * */
            int pacManCoordX = pacMan.PosX;
            int pacManCoordY = pacMan.PosY;
            System.Media.SoundPlayer eat = new System.Media.SoundPlayer(musicEating);
	        System.Media.SoundPlayer death = new System.Media.SoundPlayer(musicDeath);
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                if (keyPressed.Key == ConsoleKey.UpArrow)
                {
                    if (maze.IsThereTunnel(pacManCoordX, pacManCoordY - 1))
                    {
                        for (int index = 0; index < goldTokens.Count; index++)
                        {
                            if (goldTokens[index].IsThereGold(pacManCoordX, pacManCoordY - 1))
                            {
                                eat.Play();
                                score++;
                                goldTokens[index].RemoveFromPosition();
                                goldTokens.RemoveAt(index);
                            }
                        }

                        for (int index = 0; index < cherryTokens.Length; index++)
                        {
                            if (cherryTokens[index].IsThereCherry(pacManCoordX, pacManCoordY - 1))
                            {
                                withCherry = true;
                            }
                        }
                        

                        foreach (var enemy in ghosts)
                        {
                            if (enemy.IsThereGhost(pacManCoordX, pacManCoordY - 1))
                            {
                                if (lives > 0)
                                {
                                    if (withCherry)
                                    {
                                        
                                    }
                                    else
                                    {
                                        death.Play();
                                        lives--;
                                        Restart();
                                    }
                                    
                                }
                                else
                                {
                                    GameOverByGhost();
                                }                                
                            }
                        }

                        pacMan.Move("Up");
                    }
                }

                if (keyPressed.Key == ConsoleKey.LeftArrow)
                {
                    if (maze.IsThereTunnel(pacManCoordX - 1, pacManCoordY))
                    {
                        for (int index = 0; index < goldTokens.Count; index++)
                        {
                            if (goldTokens[index].IsThereGold(pacManCoordX - 1, pacManCoordY))
                            {
                                eat.Play();
                                score++;
                                goldTokens[index].RemoveFromPosition();
                                goldTokens.RemoveAt(index);
                            }
                        }

                        for (int index = 0; index < cherryTokens.Length; index++)
                        {
                            if (cherryTokens[index].IsThereCherry(pacManCoordX - 1, pacManCoordY))
                            {
                                withCherry = true;
                            }
                        }

                        foreach (var enemy in ghosts)
                        {
                            if (enemy.IsThereGhost(pacManCoordX - 1, pacManCoordY))
                            {
                                if (lives > 0)
                                {
                                    if (withCherry)
                                    {

                                    }
                                    else
                                    {
                                        death.Play();
                                        lives--;
                                        Restart();
                                    }
                                }
                                else
                                {
                                    GameOverByGhost();
                                }
                            }
                        }

                        pacMan.Move("Left");
                    }
                }

                if (keyPressed.Key == ConsoleKey.DownArrow)
                {
                    if (maze.IsThereTunnel(pacManCoordX, pacManCoordY + 1))
                    {
                        for (int index = 0; index < goldTokens.Count; index++)
                        {
                            if (goldTokens[index].IsThereGold(pacManCoordX, pacManCoordY + 1))
                            {
                                eat.Play();
                                score++;
                                goldTokens[index].RemoveFromPosition();
                                goldTokens.RemoveAt(index);
                            }
                        }

                        for (int index = 0; index < cherryTokens.Length; index++)
                        {
                            if (cherryTokens[index].IsThereCherry(pacManCoordX, pacManCoordY + 1))
                            {
                                withCherry = true;
                            }
                        }

                        foreach (var enemy in ghosts)
                        {
                            if (enemy.IsThereGhost(pacManCoordX, pacManCoordY + 1))
                            {
                                if (lives > 0)
                                {
                                    if (withCherry)
                                    {

                                    }
                                    else
                                    {
                                        death.Play();
                                        lives--;
                                        Restart();
                                    }
                                }
                                else
                                {
                                    GameOverByGhost();
                                }
                            }
                        }

                        pacMan.Move("Down");
                    }
                }

                if (keyPressed.Key == ConsoleKey.RightArrow)
                {
                    if (maze.IsThereTunnel(pacManCoordX + 1, pacManCoordY))
                    {
                        for (int index = 0; index < goldTokens.Count; index++)
                        {
                            if (goldTokens[index].IsThereGold(pacManCoordX + 1, pacManCoordY))
                            {
                                eat.Play();
                                score++;
                                goldTokens[index].RemoveFromPosition();
                                goldTokens.RemoveAt(index);
                            }
                        }

                        for (int index = 0; index < cherryTokens.Length; index++)
                        {
                            if (cherryTokens[index].IsThereCherry(pacManCoordX + 1, pacManCoordY))
                            {
                                withCherry = true;
                            }
                        }

                        foreach (var enemy in ghosts)
                        {
                            if (enemy.IsThereGhost(pacManCoordX + 1, pacManCoordY))
                            {
                                if (lives > 0)
                                {
                                    if (withCherry)
                                    {

                                    }
                                    else
                                    {
                                        death.Play();
                                        lives--;
                                        Restart();
                                    }
                                }
                                else
                                {
                                    GameOverByGhost();
                                }
                            }
                        }

                        pacMan.Move("Right");
                    }
                }
            }
        }

        private static void Restart()
        {
            Console.SetCursorPosition(pacMan.PosX, pacMan.PosY);
            Console.Write(' '); 
            pacMan.PosX = 13;
            pacMan.PosY = 23;
            pacMan.DrawAtPosition();
            
            for (int i = 0; i < ghosts.Length; i++)
            {
                Console.SetCursorPosition(ghosts[i].PosX, ghosts[i].PosY);
                Console.Write(' ');
                ghosts[i].PosX = 11;
                ghosts[i].PosY = 15;
            }          
        }

        static String[] Chase1(Maze maze, int ghostX, int ghostY, int pacX, int pacY)
        {
            int[] distancesSq = 
                                { 
                                ((ghostX - pacX) * (ghostX - pacX)) + ((ghostY + 1 - pacY) * (ghostY + 1 - pacY)),
                                ((ghostX - pacX) * (ghostX - pacX)) + ((ghostY - 1 - pacY) * (ghostY - 1 - pacY)),
                                ((ghostX + 1 - pacX) * (ghostX + 1 - pacX)) + ((ghostY - pacY) * (ghostY - pacY)),
                                ((ghostX - 1 - pacX) * (ghostX - 1 - pacX)) + ((ghostY - pacY) * (ghostY - pacY))
                                };            
            var tupleList = new List<Tuple<int, string>>
            {
                Tuple.Create( distancesSq[0], "Up" ),
                Tuple.Create( distancesSq[1], "Down" ),
                Tuple.Create( distancesSq[2], "Right" ),
                Tuple.Create( distancesSq[3], "Left" )
            };
            tupleList.Sort();
            String[] sorted = {tupleList[0].Item2,tupleList[1].Item2,tupleList[2].Item2,tupleList[3].Item2};
            return sorted;
        }

        static String[] Chase2(Maze maze, int ghostX, int ghostY, int pacX, int pacY)
        {
            switch (pacMan.Direction)
            {
                case "Up":
                    return Chase1(maze, ghostX, ghostY, pacX, pacY+4);
                case "Down":
                    return Chase1(maze, ghostX, ghostY, pacX, pacY-4);
                case "Right":
                    return Chase1(maze, ghostX, ghostY, pacX+4, pacY);
                case "Left":
                    return Chase1(maze, ghostX, ghostY, pacX-4, pacY);
                default:
                    break;
            }
            Console.WriteLine("error 302");
            return Chase1(maze, ghostX, ghostY, pacX, pacY);
            
        }

        static String[] Chase3(Maze maze, int ghostX, int ghostY, int pacX, int pacY)
        {
            pacX += pacX - ghostX;
            pacY += pacY - ghostY;
            return Chase1(maze, ghostX, ghostY, pacX, pacY);
        }

        static String[] Chase4(Maze maze, int ghostX, int ghostY, int pacX, int pacY)
        {
            if (Math.Abs(pacX - ghostX) + Math.Abs(pacY - ghostY) > 8)
            {
                return Chase1(maze, ghostX, ghostY, pacX, pacY);
            }

            return Chase1(maze, ghostX, ghostY, 15, 15);
        }

        static bool AreThereGhosts(int X, int Y)
        {
            foreach (Ghosts ghost in ghosts)
            {
                if (ghost.PosX == X && ghost.PosY == Y)
                {
                    return true;
                }
            }
            return false;
        }

        static void MoveGhosts()
        {
            System.Media.SoundPlayer death = new System.Media.SoundPlayer(musicDeath);
            string[] colors = new string[] { "red", "blue", "green", "cyan" };
            Dictionary<String, int[]> izmestvane = new Dictionary<string,int[]>()
            {
                {"Down", new int[] {0,- 1}},
                {"Up", new int[] {0, 1}},
                {"Right", new int[] {1, 0}},
                {"Left", new int[] {-1, 0}},
                {"Stay", new int[] {0,0}}
            };
            Dictionary<String, String> opposite = new Dictionary<string, string>()
            {
                {"Down","Up"},
                {"Up","Down"},
                {"Right","Left"},
                {"Left","Right"}
            };
            for (int i = 0; i < ghosts.Length; i++)
            {
                String choice = "Stay";
                int ghostCoordX = ghosts[i].PosX;
                int ghostCoordY = ghosts[i].PosY;
                String[] moves = {"Stay"};
                switch (i)
                {
                    case 0:
                        moves = Chase1(maze, ghosts[i].PosX, ghosts[i].PosY, pacMan.PosX, pacMan.PosY);                        
                        break;
                    case 1:
                        moves = Chase2(maze, ghosts[i].PosX, ghosts[i].PosY, pacMan.PosX, pacMan.PosY);
                        break;
                    case 2:
                        moves = Chase3(maze, ghosts[i].PosX, ghosts[i].PosY, pacMan.PosX, pacMan.PosY);
                        break;
                    case 3:
                        moves = Chase4(maze, ghosts[i].PosX, ghosts[i].PosY, pacMan.PosX, pacMan.PosY);
                        break;
                    
                    default:
                        break;
                }
                for (int j = 0; j < 4; j++)
                {
                    int[] izm = izmestvane[moves[j]];
                    if ((maze.IsThereTunnel(ghosts[i].PosX + izm[0], ghosts[i].PosY + izm[1])) ||
                        maze.IsItPrison(ghosts[i].PosX + izm[0], ghosts[i].PosY + izm[1])
                        && (!(moves[j] == opposite[ghosts[i].Direction])) &&
                        (!AreThereGhosts(ghosts[i].PosX + izm[0], ghosts[i].PosY + izm[1])))
                    {
                        choice = moves[j];
                        break;
                    }
                }

                switch (choice)
                {
                    case "Up":
                        if (maze.IsThereTunnel(ghostCoordX, ghostCoordY + 1) || maze.IsItPrison(ghostCoordX, ghostCoordY + 1))
                        {
                            if (pacMan.IsTherePacMan(ghostCoordX, ghostCoordY + 1))
                            {
                                if (lives > 0)
                                {
                                    if (withCherry)
                                    {
                                        ghosts[i].RemoveFromPreviousPosition();
                                        ghosts[i].PosX = 11;
                                        ghosts[i].PosY = 15;
                                        ghosts[i].DrawAtPosition();                                       
                                    }
                                    else
                                    {
                                        death.Play();
                                        lives--;
                                        Restart();
                                    }
                                }
                                else
                                {
                                    GameOverByGhost();
                                }
                            }
                            else
                            {
                                ghosts[i].Move(choice);

                                DrawTokenAfterGhost(ghostCoordX, ghostCoordY);
                            }
                        }

                        break;
                    case "Down":
                        if (maze.IsThereTunnel(ghostCoordX, ghostCoordY - 1) || maze.IsItPrison(ghostCoordX, ghostCoordY - 1))
                        {
                            if (pacMan.IsTherePacMan(ghostCoordX, ghostCoordY - 1))
                            {
                                if (lives > 0)
                                {
                                    if (withCherry)
                                    {
                                        ghosts[i].RemoveFromPreviousPosition();
                                        ghosts[i].PosX = 11;
                                        ghosts[i].PosY = 15;
                                        ghosts[i].DrawAtPosition(); 
                                    }
                                    else
                                    {
                                        death.Play();
                                        lives--;
                                        Restart();
                                    }
                                }
                                else
                                {
                                    GameOverByGhost();
                                }
                            }
                            else
                            {
                                ghosts[i].Move(choice);

                                DrawTokenAfterGhost(ghostCoordX, ghostCoordY);
                            }
                        }

                        break;
                    case "Right":
                        if (maze.IsThereTunnel(ghostCoordX + 1, ghostCoordY) || maze.IsItPrison(ghostCoordX + 1, ghostCoordY))
                        {
                            if (pacMan.IsTherePacMan(ghostCoordX + 1, ghostCoordY))
                            {
                                if (lives > 0)
                                {
                                    if (withCherry)
                                    {
                                        ghosts[i].RemoveFromPreviousPosition();
                                        ghosts[i].PosX = 11;
                                        ghosts[i].PosY = 15;
                                        ghosts[i].DrawAtPosition(); 
                                    }
                                    else
                                    {
                                        death.Play();
                                        lives--;
                                        Restart();
                                    }
                                }
                                else
                                {
                                    GameOverByGhost();
                                }
                            }
                            else
                            {
                                ghosts[i].Move(choice);

                                DrawTokenAfterGhost(ghostCoordX, ghostCoordY);
                            }
                        }

                        break;
                    case "Left":
                        if (maze.IsThereTunnel(ghostCoordX - 1, ghostCoordY) || maze.IsItPrison(ghostCoordX - 1, ghostCoordY))
                        {
                            if (pacMan.IsTherePacMan(ghostCoordX - 1, ghostCoordY))
                            {
                                if (lives > 0)
                                {
                                    if (withCherry)
                                    {
                                        ghosts[i].RemoveFromPreviousPosition();
                                        ghosts[i].PosX = 11;
                                        ghosts[i].PosY = 15;
                                        ghosts[i].DrawAtPosition(); 
                                    }
                                    else
                                    {
                                        death.Play();
                                        lives--;
                                        Restart();
                                    }
                                }
                                else
                                {
                                    GameOverByGhost();
                                }
                            }
                            else
                            {
                                ghosts[i].Move(choice);

                                DrawTokenAfterGhost(ghostCoordX, ghostCoordY);
                            }
                        }

                        break;
                    case "Stay":
                        ghosts[i].Move(choice);
                        continue;
                    default:
                        break;
                }
            }

            /*
            for (int i = 0; i < ghosts.Length; i++)
            {
                int[] positions = Chase2(maze.MatrixGenerator(), ghosts[i].XPos, ghosts[i].YPos, pacMan.PosX, pacMan.PosY);
                int best_possible = 0;
                int position = positions[best_possible];
                int row = ghosts[i].XPos;
                int col = ghosts[i].YPos;
                int[] izmestvane = new int[] { 0, 0 };
                while (true)
                {
                    switch (position)
                    {
                        case 0:
                            izmestvane = new int[] { 0, 1 };
                            break;
                        case 1:
                            izmestvane = new int[] { 0, -1 };
                            break;
                        case 2:
                            izmestvane = new int[] { 1, 0 };
                            break;
                        case 3:
                            izmestvane = new int[] { -1, 0 };
                            break;
                        default:
                            break;
                    }
                    int newrow = row + izmestvane[0];
                   // if (newrow < 0)
                   // {
                      //  newrow = 0;
                   // }

                    int newcol = col + izmestvane[1];
                   // if (newcol < 0)
                   // {
                      //  newcol = 0;
                   // }

                    if ((maze.MatrixGenerator()[newrow, newcol] != "│") &&
                            (maze.MatrixGenerator()[newrow, newcol] != "─") &&
                            (maze.MatrixGenerator()[newrow, newcol] != "┌") &&
                            (maze.MatrixGenerator()[newrow, newcol] != "┐") &&
                            (maze.MatrixGenerator()[newrow, newcol] != "└") &&
                            (maze.MatrixGenerator()[newrow, newcol] != "┘"))
                    {
                        if (maze.MatrixGenerator()[newrow, newcol] == "*")
                        {
                            maze.MatrixGenerator()[newrow, newcol] = "☻";
                            maze.MatrixGenerator()[row, col] = "*";
                            ghosts[i].XPos = newrow;
                            ghosts[i].YPos = newcol;
                        }
                        else if (maze[newrow, newcol] == "☺")
                        {
                            maze.FieldGenerator();
                            Console.WriteLine("Game over!");
                            Environment.Exit(0);
                        }
                        else
                        {
                            maze.MatrixGenerator()[newrow, newcol] = "☻";
                            maze.MatrixGenerator()[row, col] = " ";
                            ghosts[i].XPos = newrow;
                            ghosts[i].YPos = newcol;
                        }
                        break;
                    }
                    else
                    {
                        best_possible++;
                      //  if (best_possible > 3)
                      //  {
                       //     best_possible = 3;   
                      //  }
                        position = positions[best_possible];
                    }
                }
            }
           * */
        }

        private static void GameOverByGhost()
        {
            Console.SetCursorPosition(11, 13);
            Console.WriteLine("Game over!");
            Environment.Exit(0);
        }

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

        static void ScoreBoard()
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

            positionY = 0;
            positionX = WindowsWidth - 30;

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

        static void GenerateGhosts()
        {
            /* Този метод генерира Духовете. Избрал съм да са 3, като слага едни 
             * рандъм row и col спрамо максималните стойности, ако на тази
             * позиция има празно място го слага там, като се създава нов обект 
             * от Класа Ghost и този обект е част от масива на духовете. Записваме
             * позицията на духа.
             * със съответния символ : ☻
             * */
            int count = 0;
            do
            {
                int coordX = 12+count;
                int coordY = 15;
                string[] colors = { "red", "blue", "green", "cyan" };
                if (maze.IsItPrison(coordX, coordY))
                {
                    ghosts[count] = new Ghosts(coordX, coordY, colors[count]);
                    count++;
                    if (count == ghosts.Length)
                    {
                        break;
                    }
                }
            }
            while (true);
        }

        static void GeneratePacMan()
        {
            int row = 13;
            int col = 5;
            pacMan = new PacMan(row, col, ConsoleColor.Yellow);
        }

        static void GenerateGold()
        {
            /* Тук се генерира златото, прави се просто проверка дали полето е 
             * свободно, ако е слага символ * и вдига броя на златните кюлчета с 1
             * */
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

        static void GenerateCherry()
        {
            /* Тук се генерират черешките на точно зададени координати в 4-те ъгъла
             * */

            cherryTokens[0] = new Cherry(1, 1);
            cherryTokens[1] = new Cherry(1, MazeHeight-1);
            cherryTokens[2] = new Cherry(MazeWidth - 2, 1);
            cherryTokens[3] = new Cherry(MazeWidth - 2, MazeHeight - 1);


            DrawCherry();
        }

        private static void DrawCherry()
        {
            foreach (var token in cherryTokens)
            {
                token.DrawAtPosition();
            }
        }

        private static void DrawGold()
        {
            foreach (var token in goldTokens)
            {
                token.DrawAtPosition();
                goldCount++;
            }
        }       

        static void GenerateMaze()
        {
            string field = maze.FieldGenerator();
            Console.SetCursorPosition(0, 0);
            Console.Write(field);
        }
    }
}