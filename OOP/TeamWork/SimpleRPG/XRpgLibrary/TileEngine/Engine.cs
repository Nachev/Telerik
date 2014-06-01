namespace XTankWarsLibrary.TileEngine
{
    using System;
    using System.Linq;
    using Microsoft.Xna.Framework;

    public class Engine
    {
        private static int tileWidth;
        private static int tileHeight;
       
        public Engine(int tileWidth, int tileHeight)
        {
            Engine.tileWidth = tileWidth;
            Engine.tileHeight = tileHeight;
        }

        public static int TileWidth
        {
            get
            {
                return tileWidth;
            }
        }

        public static int TileHeight
        {
            get
            {
                return tileHeight;
            }
        }

        /// <summary>
        /// Returns specified vector on which cell of the map grid is placed.
        /// </summary>
        private Point VectorToCell(Vector2 vector)
        {
            return new Point((int)vector.X / tileWidth, (int)vector.Y / tileHeight);
        }
    }
}
