namespace TankWars.Common
{
    using System;
    public struct ItemPosition
    {
        public ItemPosition(int x, int y)
            : this()
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; set; }

        public int Y { get; set; }
    }
}
