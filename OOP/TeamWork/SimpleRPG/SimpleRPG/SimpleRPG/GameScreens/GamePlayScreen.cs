namespace TankWarsGraphics.GameScreens
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using TankWarsGraphics.Componenets;
    using XTankWarsLibrary;
    using XTankWarsLibrary.TileEngine;

    public class GamePlayScreen : BaseGameState
    {
        #region Fields
        private const int TilesSize = 32;
        private const int MapWidth = 100;
        private const int MapHeight = 100;

        private Engine engine = new Engine(TilesSize, TilesSize);
        private TileMap map;
        private Player player;
        #endregion 

        #region Constructors
        public GamePlayScreen(Game game, GameStateManager manager) : base(game, manager)
        {
            this.player = new Player(game);
        }
        #endregion

        #region Methods

        public override void Update(GameTime gameTime)
        {
            this.player.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            this.GameRef.SpriteBatch.Begin(
                SpriteSortMode.Immediate, 
                BlendState.AlphaBlend, 
                SamplerState.PointClamp, 
                null, 
                null, 
                null, 
                this.player.Camera.Transformation);

            this.map.Draw(this.GameRef.SpriteBatch, this.player.Camera);
            base.Draw(gameTime);
            this.player.Draw(this.GameRef.SpriteBatch);
            this.GameRef.SpriteBatch.End();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            Texture2D tilesetTexture = this.GameRef.Content.Load<Texture2D>(@"Tilesets\grounds_tileset");
            Tileset tilesetGround = new Tileset(tilesetTexture, TilesSize, TilesSize, 4, 1);

            tilesetTexture = this.GameRef.Content.Load<Texture2D>(@"Tilesets\obstacles_tileset");
            Tileset tilesetObstacles = new Tileset(tilesetTexture, TilesSize, TilesSize, 4, 2);

            tilesetTexture = this.GameRef.Content.Load<Texture2D>(@"Tilesets\buildings_tileset");
            Tileset tilesetBuildings = new Tileset(tilesetTexture, TilesSize, TilesSize, 8, 2);

            List<Tileset> tilesets = new List<Tileset>() { tilesetGround, tilesetObstacles, tilesetBuildings };

            MapLayer ground = new MapLayer(TxtMapReader.Load(@"Content\Maps\FinalMap.txt", 1));
            MapLayer obstacles = new MapLayer(TxtMapReader.Load(@"Content\Maps\FinalMap.txt", 2));
            MapLayer buildings = new MapLayer(TxtMapReader.Load(@"Content\Maps\FinalMap.txt", 3));
            List<MapLayer> mapLayers = new List<MapLayer>() { ground, obstacles, buildings };

            this.map = new TileMap(tilesets, mapLayers);

            tilesetTexture = this.GameRef.Content.Load<Texture2D>(@"Tilesets\fourTanks");
            Tileset tanksTileset = new Tileset(tilesetTexture, TilesSize, TilesSize, 4, 1);
            this.player.Tank = new XTankWarsLibrary.SpriteClasses.MovableSprite(tanksTileset, new Tile(0, 0));
        }
        #endregion
    }
}
