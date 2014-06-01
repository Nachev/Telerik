namespace TankWarsGraphics.GameScreens
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using XTankWarsLibrary;
    using XTankWarsLibrary.Controls;

    public class TitleScreen : BaseGameState
    {
        private Texture2D backgroundImage;
        private LinkLabel startLabel;

        public TitleScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {
        }

        public override void Update(GameTime gameTime)
        {
            this.ControlManager.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            this.GameRef.SpriteBatch.Begin();
            base.Draw(gameTime);
            this.GameRef.SpriteBatch.Draw(this.backgroundImage, this.GameRef.ScreenRectangle, Color.White);
            this.ControlManager.Draw(this.GameRef.SpriteBatch);
            this.GameRef.SpriteBatch.End();
        }

        protected override void LoadContent()
        {
            ContentManager content = this.GameRef.Content;
            this.backgroundImage = content.Load<Texture2D>(@"Backgrounds\TitleScreen");
            base.LoadContent();

            this.startLabel = new LinkLabel();
            this.startLabel.Position = new Vector2(500, 500);
            this.startLabel.Text = "Press ENTER to begin";
            this.startLabel.Color = Color.Yellow;
            this.startLabel.TabStop = true;
            this.startLabel.HasFocus = true;
            this.startLabel.Selected += new System.EventHandler(this.StartLabelSelected);

            this.ControlManager.Add(this.startLabel);
        }

        private void StartLabelSelected(object sender, System.EventArgs e)
        {
            this.StateManager.PushState(this.GameRef.StartMenuScreen);
        }
    }
}
