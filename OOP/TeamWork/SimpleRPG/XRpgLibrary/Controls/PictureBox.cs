namespace XTankWarsLibrary.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using XTankWarsLibrary.Controls;

    public class PictureBox : Control
    {
        #region Fields
        private Texture2D image;
        private Rectangle sourceRect;
        private Rectangle destinationRect;
        #endregion

        public PictureBox(Texture2D image, Rectangle destination)
        {
            this.Image = image;
            this.DestinationRect = destination;
            this.SourceRect = new Rectangle(0, 0, this.Image.Width, this.Image.Height);
            this.Color = Color.White;
        }
  
        public PictureBox(Texture2D image, Rectangle destinationRect, Rectangle sourceRect)
            : this(image, destinationRect)
        {
            this.SourceRect = sourceRect;
        }

        #region Propeties
        public Texture2D Image
        {
            get
            {
                return this.image;
            }

            set
            {
                this.image = value;
            }
        }

        public Rectangle SourceRect
        {
            get
            {
                return this.sourceRect;
            }

            set
            {
                this.sourceRect = value;
            }
        }

        public Rectangle DestinationRect
        {
            get
            {
                return this.destinationRect;
            }

            set
            {
                this.destinationRect = value;
            }
        }
        #endregion

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.image, this.destinationRect, this.sourceRect, this.Color);
        }

        public override void HandleInput()
        {
        }

        public void SetPosition(Vector2 newPosition)
        {
            this.destinationRect = new Rectangle((int)newPosition.X, (int)newPosition.Y, this.sourceRect.Width, this.sourceRect.Height);
        }
    }
}
