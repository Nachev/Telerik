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

        public Ghosts(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
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
                case "Up":
                    this.RemoveFromPreviousPosition();
                    this.posY -= 1;
                    this.DrawAtPosition();
                    break;
                case "Down":
                    this.RemoveFromPreviousPosition();
                    this.posY += 1;
                    this.DrawAtPosition();
                    break;
                case "Left":
                    this.RemoveFromPreviousPosition();
                    this.posX -= 1;
                    this.DrawAtPosition();
                    break;
                case "Right":
                    this.RemoveFromPreviousPosition();
                    this.posX += 1;
                    this.DrawAtPosition();
                    break;
                default:
                    break;
            }
        }

        private void DrawAtPosition()
        {
            Console.SetCursorPosition(this.posX, this.posY);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(this.symbol);
            Console.ResetColor();
        }

        private void RemoveFromPreviousPosition()
        {
            Console.SetCursorPosition(this.posX, this.posY);
            Console.Write(' ');
        }
    }
}