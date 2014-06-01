namespace XTankWarsLibrary.Controls
{
    using System;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class LinkLabel : Control
    {
        private Color selectedColor = Color.Red;

        public LinkLabel()
        {
            this.TabStop = true;
            this.HasFocus = false;
            this.Position = Vector2.Zero;
        }

        public Color SelectedColor
        {
            get
            {
                return this.selectedColor;
            }

            set
            {
                this.selectedColor = value;
            }
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (this.HasFocus)
            {
                spriteBatch.DrawString(this.SpriteFont, this.Text, this.Position, this.selectedColor);
            }
            else
            {
                spriteBatch.DrawString(this.SpriteFont, this.Text, this.Position, this.Color);
            }
        }

        public override void HandleInput()
        {
            if (this.HasFocus)
            {
                if (InputHandler.IsKeyReleased(Keys.Enter))
                {
                    this.OnSelected(null);
                }
            }
        }
    }
}
