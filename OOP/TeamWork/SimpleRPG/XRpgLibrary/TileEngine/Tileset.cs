namespace XTankWarsLibrary.TileEngine
{
    using System;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Tileset
    {
        #region Fields
        private Texture2D image;
        private int tileWidth;
        private int tileHeight;
        private int tilesetWidth;
        private int tilesetHeight;
        private Rectangle[] sourceRectangle;
        #endregion

        public Tileset(Texture2D image, int tileWidth, int tileHeight, int tilesetWidth, int tilesetHeight)
        {
            this.image = image;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            this.tilesetWidth = tilesetWidth;
            this.tilesetHeight = tilesetHeight;

            int tiles = tilesetWidth * tilesetHeight;

            this.sourceRectangle = new Rectangle[tiles];

            int tile = 0;

            for (int y = 0; y < tilesetHeight; y++)
            {
                for (int x = 0; x < tilesetWidth; x++)
                {
                    this.sourceRectangle[tile] = new Rectangle(x * tileWidth, y * tileHeight, tileWidth, tileHeight);
                    tile++;
                }
            }
        }

        #region Properties
        public Texture2D Texture
        {
            get
            {
                return this.image;
            }
        }

        public int TileWidth
        {
            get
            {
                return this.tileWidth;
            }
        }

        public int TileHeight
        {
            get
            {
                return this.tileHeight;
            }
        }

        public int TilesetWidth
        {
            get
            {
                return this.tilesetWidth;
            }
        }

        public int TilesetHeight
        {
            get
            {
                return this.tilesetHeight;
            }
        }

        public Rectangle[] SourceRectangle
        {
            get
            {
                return (Rectangle[])this.sourceRectangle.Clone();
            }
        }
        #endregion
    }
}
