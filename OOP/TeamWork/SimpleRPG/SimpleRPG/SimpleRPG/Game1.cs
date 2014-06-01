namespace TankWarsGraphics
{
    using System;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using TankWarsGraphics.GameScreens;
    using XTankWarsLibrary;

    /// <summary>
    /// This is the main type for the game.
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region Constants
        private const int ScreenWidth = 800;
        private const int ScreenHeight = 600;
        #endregion

        #region Fields
        private readonly Rectangle screenRectangle;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private GameStateManager stateManager;
        #endregion

        public Game1()
        {
            this.InitializeGraphics();

            this.screenRectangle = new Rectangle(0, 0, ScreenWidth, ScreenHeight);
            this.Content.RootDirectory = "Content";

            this.Components.Add(new InputHandler(this));

            this.stateManager = new GameStateManager(this);
            this.Components.Add(this.stateManager);

            this.TitleScreen = new TitleScreen(this, this.stateManager);
            this.StartMenuScreen = new StartMenuScreen(this, this.stateManager);
            this.GamePlayScreen = new GamePlayScreen(this, this.stateManager);
            this.CreditsScreen = new CreditsScreen(this, this.stateManager);

            this.stateManager.ChangeState(this.TitleScreen);
        }

        #region Properies  
        public SpriteBatch SpriteBatch
        {
            get
            {
                return this.spriteBatch;
            }

            set
            {
                this.spriteBatch = value;
            }
        }

        public TitleScreen TitleScreen { get; private set; }

        public StartMenuScreen StartMenuScreen { get; private set; }

        public GamePlayScreen GamePlayScreen { get; private set; }

        public CreditsScreen CreditsScreen { get; private set; }

        public Rectangle ScreenRectangle
        {
            get
            {
                return this.screenRectangle;
            }
        }
        #endregion

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }

        private void InitializeGraphics()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.graphics.PreferredBackBufferWidth = ScreenWidth;
            this.graphics.PreferredBackBufferHeight = ScreenHeight;
            this.Window.Title = "Team Virginia Woolf project";
        }
    }
}
