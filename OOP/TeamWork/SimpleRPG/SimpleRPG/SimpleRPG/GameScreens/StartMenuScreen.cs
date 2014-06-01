namespace TankWarsGraphics.GameScreens
{
    using System;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using TankWarsGraphics.GameScreens;
    using XTankWarsLibrary;
    using XTankWarsLibrary.Controls;

    public class StartMenuScreen : BaseGameState
    {
        #region Fields
        private PictureBox backgroundImage;
        private PictureBox arrowImage;
        private LinkLabel startGame;
        private LinkLabel gameCredits;
        private LinkLabel exitGame;
        private float maxLabelWidth = 0f; // Controls where the arrow appears in the menu.
        #endregion

        public StartMenuScreen(Game game, GameStateManager manager) : base(game, manager)
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
            this.ControlManager.Draw(this.GameRef.SpriteBatch);
            this.GameRef.SpriteBatch.End();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            ContentManager content = this.Game.Content;

            this.backgroundImage = new PictureBox(content.Load<Texture2D>(@"Backgrounds\menuScreen"), this.GameRef.ScreenRectangle);
            this.ControlManager.Add(this.backgroundImage);

            Texture2D arrowTexture = content.Load<Texture2D>(@"GUI\leftarrowUp");
            this.arrowImage = new PictureBox(arrowTexture, new Rectangle(0, 0, arrowTexture.Width, arrowTexture.Height));
            this.ControlManager.Add(this.arrowImage);

            this.startGame = new LinkLabel();
            this.startGame.Text = "The battle begins";
            this.startGame.Size = this.startGame.SpriteFont.MeasureString(this.startGame.Text);
            this.startGame.Selected += new EventHandler(this.MenuItemSelected);
            this.ControlManager.Add(this.startGame);

            this.gameCredits = new LinkLabel();
            this.gameCredits.Text = "The battle created by";
            this.gameCredits.Size = this.gameCredits.SpriteFont.MeasureString(this.gameCredits.Text);
            this.gameCredits.Selected += this.MenuItemSelected;
            this.ControlManager.Add(this.gameCredits);

            this.exitGame = new LinkLabel();
            this.exitGame.Text = "The battle ends.";
            this.exitGame.Size = this.exitGame.SpriteFont.MeasureString(this.exitGame.Text);
            this.exitGame.Selected += this.MenuItemSelected;
            this.ControlManager.Add(this.exitGame);

            this.ControlManager.NextControl(Keys.Down);

            this.ControlManager.FocusChanged += new EventHandler(this.ControlManagerFocusChanged);

            Vector2 position = new Vector2(270, 200);
            foreach (Control control in this.ControlManager)
            {
                if (control is LinkLabel)
                {
                    if (control.Size.X > this.maxLabelWidth)
                    {
                        this.maxLabelWidth = control.Size.X;
                    }

                    control.Position = position;
                    position.Y += control.Size.Y + 5f;
                }
            }

            this.ControlManagerFocusChanged(this.startGame, null);
        }

        private void ControlManagerFocusChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            Vector2 position = new Vector2(control.Position.X + this.maxLabelWidth + 10f, control.Position.Y);
            this.arrowImage.SetPosition(position);
        }

        private void MenuItemSelected(object sender, EventArgs e)
        {
            if (sender == this.startGame)
            {
                this.StateManager.PushState(this.GameRef.GamePlayScreen);
            }
            else if (sender == this.gameCredits)
            {
                this.StateManager.PushState(this.GameRef.CreditsScreen);
            }
            else if (sender == this.exitGame)
            {
                this.GameRef.Exit();
            }
        }
    }
}
