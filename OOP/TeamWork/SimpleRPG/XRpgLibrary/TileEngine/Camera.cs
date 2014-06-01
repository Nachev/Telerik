namespace XTankWarsLibrary.TileEngine
{
    using System;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using XTankWarsLibrary.SpriteClasses;

    public class Camera
    {
        #region Fields
        private const float MaxCameraSpeed = 16f;
        private const float DefaultCameraSpeed = 4f;

        private Vector2 position;
        private float speed;
        private float zoom;
        private Rectangle viewportRectangle;
        private bool lockToPlayer = true;
        #endregion

        #region Constructors
        public Camera(Rectangle viewportRectangle)
        {
            this.speed = DefaultCameraSpeed;
            this.zoom = 1f;
            this.viewportRectangle = viewportRectangle;
        }

        public Camera(Rectangle viewportRectangle, Vector2 position)
            : this(viewportRectangle)
        {
            this.position = position;
        }
        #endregion

        #region Properties
        public bool LockToPlayer
        {
            get
            {
                return this.lockToPlayer;
            }
            set
            {
                this.lockToPlayer = value;
            }
        }

        public Matrix Transformation
        {
            get
            {
                return Matrix.CreateScale(this.zoom) * Matrix.CreateTranslation(new Vector3(-this.position, 0f));
            }
        }

        public Rectangle ViewportRectangle
        {
            get
            {
                return new Rectangle(
                    viewportRectangle.X,
                    viewportRectangle.Y,
                    viewportRectangle.Width,
                    viewportRectangle.Height);
            }
        }

        public Vector2 Position
        {
            get
            {
                return this.position;
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
                this.speed = MathHelper.Clamp(value, 1f, MaxCameraSpeed);
            }
        }

        public float Zoom
        {
            get
            {
                return this.zoom;
            }
        }
        #endregion

        #region Methods
        public void Update(GameTime gameTime)
        {
            if (!lockToPlayer)
            {
                Vector2 moveDirection = Vector2.Zero;

                if (InputHandler.IsKeyDown(Keys.Left))
                {
                    moveDirection.X = -this.speed;
                }
                else if (InputHandler.IsKeyDown(Keys.Right))
                {
                    moveDirection.X = this.speed;
                }

                if (InputHandler.IsKeyDown(Keys.Up))
                {
                    moveDirection.Y = -this.speed;
                }
                else if (InputHandler.IsKeyDown(Keys.Down))
                {
                    moveDirection.Y = this.speed;
                }

                // Gives equal speed by diagonal.
                if (moveDirection != Vector2.Zero)
                {
                    moveDirection.Normalize();
                    this.position += moveDirection * this.speed;
                    this.LockCamera();
                }
            }
        }

        /// <summary> Locks the camera in side map borders. </summary>
        public void LockCamera()
        {
            this.position = Vector2.Clamp(
                this.position,
                Vector2.Zero,
                new Vector2(
                    TileMap.WidthInPixels - this.viewportRectangle.Width, 
                    TileMap.HeightInPixels - this.viewportRectangle.Height));
        }

        public void LockCameraToPlayer(MovableSprite sprite)
        {
            position.X = (sprite.Position.X + sprite.Width / 2) * zoom
                            - (viewportRectangle.Width / 2);
            position.Y = (sprite.Position.Y + sprite.Height / 2) * zoom
                            - (viewportRectangle.Height / 2);
            LockCamera();
        }

        public void ToggleCameraMode()
        {
            this.lockToPlayer = this.lockToPlayer ? false : true;
        }
        #endregion
    }
}
