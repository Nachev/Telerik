namespace XTankWarsLibrary.SpriteClasses
{
    using System;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using XTankWarsLibrary.TileEngine;

    public class MovableSprite
    {
        #region Field
        private const float MaxSpeed = 16.0f;
        private const float MinSpeed = 1.00f;
        private const float DefaultSpeed = 2.0f;
        private const float RotationSpeed = MathHelper.Pi / 60;

        private Tileset tileset;
        private Tile tile;
        private Vector2 position;
        private Vector2 velocity;
        private float rotationAngle = 0.00f;
        private float speed = DefaultSpeed;
        private bool isRotating = false;
        private Direction direction = Direction.Up;
        private Direction formerDirection;
        #endregion

        #region Constructor
        public MovableSprite(Tileset tileset, Tile tile)
        {
            this.tileset = tileset;
            this.tile = tile;
            this.isRotating = true;
            this.rotationAngle = 0.0f;
            this.speed = DefaultSpeed;
            this.direction = Direction.Up;
            this.formerDirection = Direction.Up;
        }
        #endregion

        #region Property
        public float RotationAngle
        {
            get
            {
                return this.rotationAngle;
            }
            set
            {
                this.rotationAngle = value;
            }
        }

        public Direction Direction
        {
            get
            {
                return this.direction;
            }

            set
            {
                this.direction = value;
            }
        }

        public bool IsRotating
        {
            get
            {
                return this.isRotating;
            }

            set
            {
                this.isRotating = value;
            }
        }

        public Tileset Tileset
        {
            get
            {
                return this.tileset;
            }
        }

        public Tile Tile
        {
            get
            {
                return this.tile;
            }
        }

        public int Width
        {
            get
            {
                return this.tileset.TileWidth;
            }
        }

        public int Height
        {
            get
            {
                return this.tileset.TileHeight;
            }
        }

        public float Speed
        {
            get
            {
                return this.speed;
            }

            set
            {
                this.speed = MathHelper.Clamp(this.speed, MinSpeed, MaxSpeed);
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

        public Vector2 Velocity
        {
            get
            {
                return this.velocity;
            }

            set
            {
                this.velocity = value;
                if (this.velocity != Vector2.Zero)
                {
                    this.velocity.Normalize();
                }
            }
        }
        #endregion

        #region Method
        public void Update(GameTime gameTime)
        {
            if (this.isRotating)
            {
                Matrix rotMatrix = Matrix.CreateRotationZ(this.rotationAngle);

            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                this.tileset.Texture,
                new Rectangle((int)this.position.X, (int)this.position.Y, Engine.TileWidth, Engine.TileHeight),
                this.tileset.SourceRectangle[this.tile.TileIndex],
                Color.White,
                this.rotationAngle,
                new Vector2(Engine.TileWidth / 2, Engine.TileHeight / 2),
                SpriteEffects.None, 0);
        }

        public void LockToMap()
        {
            this.position.X = MathHelper.Clamp(this.position.X, 0, TileMap.WidthInPixels - this.Width);
            this.position.Y = MathHelper.Clamp(this.position.Y, 0, TileMap.HeightInPixels - this.Height);
        }
        #endregion
    }
}
