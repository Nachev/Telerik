namespace XTankWarsLibrary.TileEngine
{
    using System;
    using System.Linq;

    /// <summary>
    /// Struct defining tile position in tileset.
    /// </summary>
    public struct Tile
    {
        // Index in a tileset.
        private int tileIndex;
        private int tileset;

        public Tile(int tileset, int tileIndex)
        {
            this.tileIndex = tileIndex;
            this.tileset = tileset;
        }

        public int TileIndex
        {
            get
            {
                return this.tileIndex;
            }
        }

        public int Tileset
        {
            get
            {
                return this.tileset;
            }
        }
    }
}
