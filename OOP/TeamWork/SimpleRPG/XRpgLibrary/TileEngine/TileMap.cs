namespace XTankWarsLibrary.TileEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using XTankWarsLibrary.Exeptions;

    public class TileMap
    {
        #region Fields
        private static int mapWidth;
        private static int mapHeight;

        private List<Tileset> tilesets;
        private List<MapLayer> mapLayers;
        #endregion

        #region Constructors
        public TileMap(List<Tileset> tilesets, List<MapLayer> mapLayers)
        {
            this.tilesets = tilesets;
            this.mapLayers = mapLayers;

            mapWidth = mapLayers[0].Width; // Index 0 is main layer
            mapHeight = mapLayers[0].Height;

            // Chek layers for compatibility
            for (int index = 1; index < mapLayers.Count; index++)
            {
                if (mapWidth != mapLayers[index].Width || mapHeight != mapLayers[index].Height)
                {
                    throw new MapLayerIncompatibilityException(index);
                }
            }
        }

        public TileMap(Tileset tileset, MapLayer layer)
        {
            this.tilesets = new List<Tileset>(1) { tileset };
            this.mapLayers = new List<MapLayer>(1) { layer };

            mapWidth = this.mapLayers[0].Width;
            mapHeight = this.mapLayers[0].Height;
        }
        #endregion

        #region Properties
        public static int WidthInPixels
        {
            get
            {
                return mapWidth * Engine.TileWidth;
            }
        }

        public static int HeightInPixels
        {
            get
            {
                return mapHeight * Engine.TileHeight;
            }
        }
        #endregion

        #region Methods
        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            Rectangle destinationRect = new Rectangle(0, 0, Engine.TileWidth, Engine.TileHeight);
            Tile tempTile;

            foreach (MapLayer layer in this.mapLayers)
            {
                for (int y = 0; y < layer.Height; y++)
                {
                    // Offset destination rectangle.
                    destinationRect.Y = (y * Engine.TileHeight) - (int)camera.Position.Y;

                    for (int x = 0; x < layer.Width; x++)
                    {
                        tempTile = layer.GetTile(x, y);

                        if (tempTile.TileIndex >= 0 && tempTile.Tileset >= 0)
                        {
                            // Offset destination rectangle.
                            destinationRect.X = (x * Engine.TileWidth) - (int)camera.Position.X;

                            spriteBatch.Draw(
                                this.tilesets[tempTile.Tileset].Texture,
                                destinationRect,
                                this.tilesets[tempTile.Tileset].SourceRectangle[tempTile.TileIndex],
                                Color.White);
                        }
                    }
                }
            }
        }

        public void AddLayer(MapLayer newLayer)
        {
            if (newLayer.Width != mapWidth && newLayer.Height != mapHeight)
            {
                throw new MapLayerIncompatibilityException("Added layer dimensions are incorrect.");
            }

            this.mapLayers.Add(newLayer);
        }
        #endregion
    }
}
