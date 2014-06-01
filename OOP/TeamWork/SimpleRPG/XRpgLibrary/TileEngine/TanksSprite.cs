using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XTankWarsLibrary.TileEngine
{
    public class TanksSprite
    {
        private Tile[] tanks;

        public TanksSprite(Tile[] tanks)
        {
            this.tanks = tanks;
        }

        public int Lenght
        {
            get
            {
                return this.tanks.Length;
            }
        }

        public Tile GetTile(int number)
        {
            return this.tanks[number];
        }

        public void SetTile(int number, Tile tile)
        {
            this.tanks[number] = tile;
        }

        public void SetTile(int number, int tileIndex, int tileset)
        {
            this.tanks[number] = new Tile(tileIndex, tileset);
        }
    }
}
