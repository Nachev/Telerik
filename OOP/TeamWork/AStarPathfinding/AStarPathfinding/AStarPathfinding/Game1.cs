namespace AStarPathfinding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.GamerServices;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Media;

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        GraphicsDevice device;
        SpriteBatch spriteBatch;
        Pathfinder pathfinder;
        DrawableObject zombie;
        List<Texture2D> mapTextures = new List<Texture2D>();

        Map map;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// </summary>
        protected override void Initialize()
        {
            // Initialize window
            GraphicsInitialization();

            this.map = new Map(this);

            pathfinder = new Pathfinder(map);
            Stack<Vector2> path = pathfinder.FindPath(new Point(0, 0), map, new Point(12, 26));

            foreach (Vector2 point in path)
            {
                System.Diagnostics.Debug.WriteLine(point);
            }

            zombie = new DrawableObject(this, Vector2.Zero);
            zombie.Path = path;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent is the place to load all of the content.
        /// </summary>
        protected override void LoadContent()
        {
            device = graphics.GraphicsDevice;

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            zombie.SetTexture(Content.Load<Texture2D>("zombiesStrip10"));

            mapTextures.Add(Content.Load<Texture2D>("Grass"));
            mapTextures.Add(Content.Load<Texture2D>("Dirt"));
            mapTextures.Add(Content.Load<Texture2D>("Rock"));
            mapTextures.Add(Content.Load<Texture2D>("Tree"));

            map.SetTextures(mapTextures);
        }

        /// <summary>
        /// UnloadContent is the place to unload all content.
        /// </summary>
        protected override void UnloadContent()
        {
            
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            zombie.Update(gameTime);
            map.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            base.Draw(gameTime);
            //map.Draw(spriteBatch);
            //zombie.Draw(spriteBatch);

            spriteBatch.End();

        }

        /// <summary>
        /// Initialize window.
        /// </summary>
        private void GraphicsInitialization()
        {
            graphics.PreferredBackBufferWidth = (int)Global.WindowWidth;
            graphics.PreferredBackBufferHeight = (int)Global.WindowHeight;
            graphics.IsFullScreen = false;
            IsMouseVisible = true;
            graphics.ApplyChanges();
            Window.Title = "Team Virginia Wolf RPG";
        }
    }
}
