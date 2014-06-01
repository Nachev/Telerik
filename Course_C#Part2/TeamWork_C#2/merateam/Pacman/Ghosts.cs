namespace PacmanGame
{
    using System;
    using System.Threading;

    public class Ghosts : MovableObject
    {
        private const int StartingPosX = 11;
        private const int StartingPosY = 15;
        private int posX;
        private int posY;
        private char symbol = '☻';
        private MoveDirection direct = MoveDirection.Down;
        private ConsoleColor color;

        public Ghosts(int posX, int posY, ConsoleColor color)
            : base(posX, posY, color)
        {
        }

        public void ResetPosition()
        {
            this.RemoveFromPreviousPosition();
            this.posX = StartingPosX;
            this.posY = StartingPosY;
            this.Draw();
        }
    }
}