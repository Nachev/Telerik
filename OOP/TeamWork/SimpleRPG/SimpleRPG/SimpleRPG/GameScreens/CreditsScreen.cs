namespace TankWarsGraphics.GameScreens
{
    using System;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using TankWarsGraphics.GameScreens;
    using XTankWarsLibrary;
    using XTankWarsLibrary.Controls;

    public class CreditsScreen : BaseGameState
    {
        private PictureBox backgroundImage;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private LinkLabel endLabel;

        public CreditsScreen(Game game, GameStateManager manager) : base(game, manager)
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

            ContentManager content = this.GameRef.Content;

            this.backgroundImage = new PictureBox(content.Load<Texture2D>(@"Backgrounds\CreditsBackGround"), this.GameRef.ScreenRectangle);
            this.ControlManager.Add(this.backgroundImage);

            this.label1 = new Label();
            this.label1.Text = "Nikolay Nachev";
            this.label1.Color = Color.Red;
            this.label1.Position = new Vector2(150, 90);

            this.ControlManager.Add(this.label1);

            this.label2 = new Label();
            this.label2.Text = "Ladislav Grigorov";
            this.label2.Color = Color.Red;
            this.label2.Position = new Vector2(150, 180);

            this.ControlManager.Add(this.label2);

            this.label3 = new Label();
            this.label3.Text = "Stoyan Penchev";
            this.label3.Color = Color.Red;
            this.label3.Position = new Vector2(150, 270);

            this.ControlManager.Add(this.label3);

            this.label4 = new Label();
            this.label4.Text = "Ivaylo Hristov";
            this.label4.Color = Color.Red;
            this.label4.Position = new Vector2(150, 360);

            this.ControlManager.Add(this.label4);

            this.label5 = new Label();
            this.label5.Text = "Ivan Markov";
            this.label5.Color = Color.Red;
            this.label5.Position = new Vector2(150, 450);

            this.ControlManager.Add(this.label5);

            this.endLabel = new LinkLabel();
            this.endLabel.Text = "Press ENTER to get back to previous menu.";
            this.endLabel.Position = new Vector2((this.GameRef.Window.ClientBounds.Width - this.endLabel.SpriteFont.MeasureString(this.endLabel.Text).X) / 2, 500);
            this.endLabel.HasFocus = true;
            this.endLabel.Selected += this.EndLabel_Selected;

            this.ControlManager.Add(this.endLabel);
        }

        private void EndLabel_Selected(object sender, EventArgs e)
        {
            this.StateManager.PopState();
        }
    }
}
