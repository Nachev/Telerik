namespace PacmanGame
{
    using System;

    interface IMovable
    {
        MoveDirection GetDirection { get; }

        void Move(MoveDirection direction);
    }
}
