namespace XTankWarsLibrary.TileEngine
{
    using System;
    using System.Linq;

    public class MapLayer
    {
        #region Fields
        private Tile[,] map;
        #endregion

        #region Constructors
        public MapLayer(Tile[,] map)
        {
            this.map = (Tile[,])map.Clone();
        }

        public MapLayer(int width, int height)
        {
            this.map = new Tile[width, height];
        }
        #endregion

        #region Properties
        public int Width
        {
            get
            {
                return this.map.GetLength(1);
            }
        }

        public int Height
        {
            get
            {
                return this.map.GetLength(0);
            }
        }
        #endregion

        #region Public Methods
        public Tile GetTile(int x, int y)
        {
            return this.map[y, x];
        }

        public void SetTile(int x, int y, Tile tile)
        {
            this.map[y, x] = tile;
        }

        public void SetTile(int x, int y, int tileIndex, int tileset)
        {
            this.map[y, x] = new Tile(tileIndex, tileset);
        }
        #endregion
    }
}
