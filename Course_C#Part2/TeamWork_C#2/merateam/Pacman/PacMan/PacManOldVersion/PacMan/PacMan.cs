namespace PacmanGame
{
    using System;

    public class PacMan
    {
        // Класа за ПакМенчето - просто пази позицията му
        private int posX;
        private int posY;
        private String direct = "Up";
        private char symbol = '☺';
        private ConsoleColor color;

        public PacMan(int posX, int posY, ConsoleColor color)
        {
            this.RemoveFromPreviousPosition();
            this.posX = posX;
            this.posY = posY;
            this.color= color;
            this.DrawAtPosition();
        }

        public ConsoleColor Color
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
            this.Direction = direction;
        }

        public bool IsTherePacMan(int objectCoordX, int objectCoordY)
        {
            bool isThereCollission = new bool();
            if (this.posX == objectCoordX && this.posY == objectCoordY)
            {
                isThereCollission = true;
            }

            return isThereCollission;
        }

        public void DrawAtPosition()
        {
            Console.SetCursorPosition(this.posX, this.posY);
            Console.ForegroundColor = this.color;
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