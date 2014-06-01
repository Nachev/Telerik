namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class Mines
	{
		static void Main(string[] args)
		{
			string command = string.Empty;
			char[,] field = GenerateField();
			char[,] bombs = PlaceTheBombs();
			int counter = 0;
			bool detonation = false;
			List<Points> hallOfFame = new List<Points>(6);
			int row = 0;
			int column = 0;
			bool flag = true; // TODO: Check meaning!
            const int Max = 35; // TODO: Check meaning!
            bool flag2 = false; // TODO: Check meaning!

			do
			{
				if (flag)
				{
					Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
					" Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
					dumpp(field);
					flag = false;
				}
				Console.Write("Daj red i kolona : ");
				command = Console.ReadLine().Trim();
				if (command.Length >= 3)
				{
					if (int.TryParse(command[0].ToString(), out row) &&
					int.TryParse(command[2].ToString(), out column) &&
						row <= field.GetLength(0) && column <= field.GetLength(1))
					{
						command = "turn";
					}
				}
				switch (command)
				{
					case "top":
						ScoreLadder(hallOfFame);
						break;
					case "restart":
						field = GenerateField();
						bombs = PlaceTheBombs();
						dumpp(field);
						detonation = false;
						flag = false;
						break;
					case "exit":
						Console.WriteLine("4a0, 4a0, 4a0!");
						break;
					case "turn":
						if (bombs[row, column] != '*')
						{
							if (bombs[row, column] == '-')
							{
								PlayersTurn(field, bombs, row, column);
								counter++;
							}
							if (Max == counter)
							{
								flag2 = true;
							}
							else
							{
								dumpp(field);
							}
						}
						else
						{
							detonation = true;
						}
						break;
					default:
						Console.WriteLine("\nGreshka! nevalidna Komanda\n");
						break;
				}
				if (detonation)
				{
					dumpp(bombs);
					Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
						"Daj si niknejm: ", counter);
					string niknejm = Console.ReadLine();
					Points t = new Points(niknejm, counter);
					if (hallOfFame.Count < 5)
					{
						hallOfFame.Add(t);
					}
					else
					{
						for (int i = 0; i < hallOfFame.Count; i++)
						{
							if (hallOfFame[i].PointsCount < t.PointsCount)
							{
								hallOfFame.Insert(i, t);
								hallOfFame.RemoveAt(hallOfFame.Count - 1);
								break;
							}
						}
					}
					hallOfFame.Sort((Points r1, Points r2) => r2.Name.CompareTo(r1.Name));
					hallOfFame.Sort((Points r1, Points r2) => r2.PointsCount.CompareTo(r1.PointsCount));
					ScoreLadder(hallOfFame);

					field = GenerateField();
					bombs = PlaceTheBombs();
					counter = 0;
					detonation = false;
					flag = true;
				}
				if (flag2)
				{
					Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
					dumpp(bombs);
					Console.WriteLine("Daj si imeto, batka: ");
					string name = Console.ReadLine();
					Points currentPoints = new Points(name, counter);
					hallOfFame.Add(currentPoints);
					ScoreLadder(hallOfFame);
					field = GenerateField();
					bombs = PlaceTheBombs();
					counter = 0;
					flag2 = false;
					flag = true;
				}
			}
			while (command != "exit");
			Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
			Console.WriteLine("AREEEEEEeeeeeee.");
			Console.Read();
		}

		private static void ScoreLadder(List<Points> points)
		{
			Console.WriteLine("\nTo4KI:");
			if (points.Count > 0)
			{
				for (int i = 0; i < points.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} kutii",
						i + 1, points[i].Name, points[i].PointsCount);
				}
				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("prazna klasaciq!\n");
			}
		}

		private static void PlayersTurn(char[,] field,
			char[,] bombs, int row, int column)
		{
			char bombsCount = CountBombs(bombs, row, column);
			bombs[row, column] = bombsCount;
			field[row, column] = bombsCount;
		}

		private static void dumpp(char[,] board)
		{
			int rows = board.GetLength(0);
			int cols = board.GetLength(1);
			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");
			for (int i = 0; i < rows; i++)
			{
				Console.Write("{0} | ", i);
				for (int j = 0; j < cols; j++)
				{
					Console.Write(string.Format("{0} ", board[i, j]));
				}
				Console.Write("|");
				Console.WriteLine();
			}
			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] GenerateField()
		{
			int boardRows = 5;
			int boardColumns = 10;
			char[,] board = new char[boardRows, boardColumns];
			for (int i = 0; i < boardRows; i++)
			{
				for (int j = 0; j < boardColumns; j++)
				{
					board[i, j] = '?';
				}
			}

			return board;
		}

		private static char[,] PlaceTheBombs()
		{
			int rows = 5;
			int cols = 10;
			char[,] gameField = new char[rows, cols];

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					gameField[i, j] = '-';
				}
			}

			List<int> minesList = new List<int>();
			while (minesList.Count < 15)
			{
				Random random = new Random();
				int nextMine = random.Next(50);
				if (!minesList.Contains(nextMine))
				{
					minesList.Add(nextMine);
				}
			}

			foreach (var mine in minesList)
			{
				int col = (mine / cols);
				int row = (mine % cols);
				if (row == 0 && mine != 0)
				{
					col--;
					row = cols;
				}
				else
				{
					row++;
				}

				gameField[col, row - 1] = '*';
			}

			return gameField;
		}

		private static void Account(char[,] playfield)
		{
			int col = playfield.GetLength(0);
			int row = playfield.GetLength(1);

			for (int i = 0; i < col; i++)
			{
				for (int j = 0; j < row; j++)
				{
					if (playfield[i, j] != '*')
					{
						char bombsCount = CountBombs(playfield, i, j);
						playfield[i, j] = bombsCount;
					}
				}
			}
		}

		private static char CountBombs(char[,] r, int rr, int rrr)
		{
			int bombsCount = 0;
			int rows = r.GetLength(0);
			int columns = r.GetLength(1);

			if (rr - 1 >= 0)
			{
				if (r[rr - 1, rrr] == '*')
				{ 
					bombsCount++; 
				}
			}
			if (rr + 1 < rows)
			{
				if (r[rr + 1, rrr] == '*')
				{ 
					bombsCount++; 
				}
			}
			if (rrr - 1 >= 0)
			{
				if (r[rr, rrr - 1] == '*')
				{ 
					bombsCount++;
				}
			}
			if (rrr + 1 < columns)
			{
				if (r[rr, rrr + 1] == '*')
				{ 
					bombsCount++;
				}
			}
			if ((rr - 1 >= 0) && (rrr - 1 >= 0))
			{
				if (r[rr - 1, rrr - 1] == '*')
				{ 
					bombsCount++; 
				}
			}
			if ((rr - 1 >= 0) && (rrr + 1 < columns))
			{
				if (r[rr - 1, rrr + 1] == '*')
				{ 
					bombsCount++; 
				}
			}
			if ((rr + 1 < rows) && (rrr - 1 >= 0))
			{
				if (r[rr + 1, rrr - 1] == '*')
				{ 
					bombsCount++; 
				}
			}
			if ((rr + 1 < rows) && (rrr + 1 < columns))
			{
				if (r[rr + 1, rrr + 1] == '*')
				{ 
					bombsCount++; 
				}
			}

			return char.Parse(bombsCount.ToString());
		}
	}
}
