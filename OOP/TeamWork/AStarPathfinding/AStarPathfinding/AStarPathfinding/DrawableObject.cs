namespace AStarPathfinding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DrawableObject : DrawableGameComponent
    {
        private Vector2 position;
        private Stack<Vector2> path;
        private Texture2D texture;
        private Rectangle imageFrame;
        private Vector2 speed;

        public DrawableObject(Game game) : base(game)
        {
            this.imageFrame = new Rectangle(0, 0, (int)Global.TileSize, (int)Global.TileSize);
        }

        public DrawableObject(Game game, Vector2 position)
            : this(game)
        {
            this.position = position;
        }

        public Vector2 Speed
        {
            get
            {
                return this.speed;
            }
        }

        public void LoadContent(GraphicsDevice device)
        {
        }

        public override void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Milliseconds % 99 == 1)
            {
                this.position = this.Path.Pop();
                this.imageFrame.X += (int)Global.TileSize;
                this.imageFrame.X %= (int)Global.TileSize * 10;
            }
        }

        public Vector2 Position
        {
            get
            {
                return this.position;
            }

            set
            {
                this.position = value;
            }
        }

        public Texture2D Texture
        {
            get
            {
                return this.texture;
            }
        }

        public Stack<Vector2> Path
        {
            get
            {
                return this.path;
            }

            set
            {
                this.path = value;
            }
        }

        public void SetTexture(Texture2D texture)
        {
            this.texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.texture == null)
            {
                return;
            }

            spriteBatch.Draw(this.texture, this.Position, this.imageFrame, Color.White);
        }
    }
}
