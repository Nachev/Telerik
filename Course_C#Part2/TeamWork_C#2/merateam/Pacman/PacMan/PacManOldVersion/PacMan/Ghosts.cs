namespace PacmanGame
{
    using System;
    using System.Threading;

    public class Ghosts
    {
        // Нов клас за духовете, те са "└", като за тях се пази позицията им
        private int posX;
        private int posY;
        private char symbol = '☻';
        private String direct = "Down";
        private String color;

        public Ghosts(int posX, int posY, string color)
        {
            this.posX = posX;
            this.posY = posY;
            this.color = color;
            this.DrawAtPosition();
        }

        public int PosX
        {
            get 
            {
                return this.posX; 
            }

            set 
            {
                this.posX = value; 
            } 
        }

        public int PosY
        {
            get
            {
                return this.posY;
            }

            set
            {
                this.posY = value;
            }
        }

        public string Color
        {
            get
            {
                return this.color;
            }

            set
            {
                this.color = value;
            }
        }
        public String Direction
        {
            get
            {
                return this.direct;
            }
            set
            {
                this.direct = value;
            }
        }
        

        public bool IsThereGhost(int objectCoordX, int objectCoordY)
        {
            bool isThereCollission = new bool();
            if (this.posX == objectCoordX && this.posY == objectCoordY)
            {
                isThereCollission = true;
            }

            return isThereCollission;
        }
        
        public void Move(string direction)
        {
            switch (direction)
            {
                case "Down":
                    this.RemoveFromPreviousPosition();
                    this.posY -= 1;
                    this.DrawAtPosition();
                    this.Direction = direction;
                    break;
                case "Up":
                    this.RemoveFromPreviousPosition();
                    this.posY += 1;
                    this.DrawAtPosition();
                    this.Direction = direction;
                    break;
                case "Right":
                    this.RemoveFromPreviousPosition();
                    this.posX += 1;
                    this.DrawAtPosition();
                    this.Direction = direction;
                    break;
                case "Left":
                    this.RemoveFromPreviousPosition();
                    this.posX -= 1;
                    this.DrawAtPosition();
                    this.Direction = direction;
                    break;
                case "Stay":
                    break;
                default:
                    break;
            }
        }

        public void DrawAtPosition()
        {
            Console.SetCursorPosition(this.posX, this.posY);
            switch (this.color)
            {
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "cyan":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                default:
                    break;
            }
            //Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(this.symbol);
            Console.ResetColor();
        }

        public void RemoveFromPreviousPosition()
        {
            Console.SetCursorPosition(this.posX, this.posY);
            Console.Write(' ');
        }
    }
}