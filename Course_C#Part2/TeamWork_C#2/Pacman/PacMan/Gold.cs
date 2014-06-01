namespace Pacman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Gold
    {
        private int posX;
        private int posY;
        private char symbol = '*';

        public Gold(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
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

        public void DrawAtPosition()
        {
            Console.SetCursorPosition(this.posX, this.posY);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(this.symbol);
            Console.ResetColor();
        }

        public void RemoveFromPosition()
        {
            Console.SetCursorPosition(this.posX, this.posY);
            Console.Write(' ');
        }

        public bool IsThereGold(int objectCoordX, int objectCoordY)
        {
            bool isThereCollission = new bool();
            if (this.posX == objectCoordX && this.posY == objectCoordY)
            {
                isThereCollission = true;
            }

            return isThereCollission;
        }
    }
}
