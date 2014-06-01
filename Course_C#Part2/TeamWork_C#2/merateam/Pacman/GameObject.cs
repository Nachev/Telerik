namespace PacmanGame
{
    using System;

    public abstract class GameObject
    {
        private char symbol;
        private int posX;
        private int posY;
        private ConsoleColor color;

        public GameObject(int posX, int posY, ConsoleColor color)
        {
            this.posX = posX;
            this.posY = posY;
            this.color = color;
            this.Draw();
        }

        public ConsoleColor Color
        {
            get
            {
                return this.color;
            }
        }

        public int PosX
        {
            get
            {
                return this.posX;
            }
        }

        public int PosY
        {
            get
            {
                return this.posY;
            }
        }

        public bool IsThereObject(int objectCoordX, int objectCoordY)
        {
            bool isThereCollission = new bool();
            if (this.posX == objectCoordX && this.posY == objectCoordY)
            {
                isThereCollission = true;
            }

            return isThereCollission;
        }

        protected void Draw()
        {
            Console.SetCursorPosition(this.posX, this.posY);
            Console.ForegroundColor = this.color;
            Console.Write(symbol);
            Console.ResetColor();
        }
    }
}