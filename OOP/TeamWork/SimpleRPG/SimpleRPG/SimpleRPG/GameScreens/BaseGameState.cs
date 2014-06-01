namespace TankWarsGraphics.GameScreens
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using TankWarsGraphics;
    using XTankWarsLibrary;
    using XTankWarsLibrary.Controls;

    public abstract partial class BaseGameState : GameState
    {
        private Game1 gameRef;
        private ControlManager controlManager;

        public BaseGameState(Game game, GameStateManager manager)
            : base(game, manager)
        {
            // Creates a reference to the main game.
            this.gameRef = (Game1)game;
        }

        protected Game1 GameRef
        {
            get
            {
                return this.gameRef;
            }
        }

        protected ControlManager ControlManager
        {
            get
            {
                return this.controlManager;
            }
        }

        protected override void LoadContent()
        {
            ContentManager content = this.gameRef.Content;
            SpriteFont menuFont = content.Load<SpriteFont>(@"Fonts\ControlFont");
            this.controlManager = new ControlManager(menuFont);

            base.LoadContent();
        }
    }
}
