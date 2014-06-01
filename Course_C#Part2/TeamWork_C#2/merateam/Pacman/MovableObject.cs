namespace PacmanGame
{
    using System;

    public abstract class MovableObject : GameObject, IMovable
    {
        private char symbol;
        private int posX;
        private int posY;
        private MoveDirection direct;
        private ConsoleColor color;

        public MovableObject(int posX, int posY, ConsoleColor color)
            : base (posX, posY, color)
        {
        }

        public MoveDirection GetDirection
        {
            get
            {
                return this.direct;
            }
        }

        public void Move(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Up:
                    this.RemoveFromPreviousPosition();
                    this.posY -= 1;
                    this.Draw();
                    break;
                case MoveDirection.Down:
                    this.RemoveFromPreviousPosition();
                    this.posY += 1;
                    this.Draw();
                    break;
                case MoveDirection.Left:
                    this.RemoveFromPreviousPosition();
                    this.posX -= 1;
                    this.Draw();
                    break;
                case MoveDirection.Right:
                    this.RemoveFromPreviousPosition();
                    this.posX += 1;
                    this.Draw();
                    break;
                default:
                    break;
            }

            this.direct = direction;
        }

        protected void RemoveFromPreviousPosition()
        {
            Console.SetCursorPosition(this.posX, this.posY);
            Console.Write(' ');
        }
    }
}