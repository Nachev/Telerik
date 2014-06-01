namespace PacmanGame
{
    using PacmanGame;
    using System;

    public class PacMan : MovableObject, IMovable
    {
        private const char symbol = '☺';
        private int posX;
        private int posY;
        private MoveDirection direct = MoveDirection.Up;
        private ConsoleColor color;

        public PacMan(int posX = 13, int posY = 5, ConsoleColor color = ConsoleColor.Yellow)
            : base(posX, posY, color)
        {
        }

        public void SetGhostEater()
        {
            this.color = ConsoleColor.Red;
            this.Draw();
        }

        public void SetNormal()
        {
            this.color = ConsoleColor.Yellow;
            this.Draw();
        }
    }
}