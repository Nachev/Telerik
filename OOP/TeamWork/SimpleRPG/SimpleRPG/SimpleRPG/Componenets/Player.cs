namespace TankWarsGraphics.Componenets
{
    using System;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using TankWarsGraphics;
    using TankWarsLibrary.Tanks;
    using XTankWarsLibrary;
    using XTankWarsLibrary.SpriteClasses;
    using XTankWarsLibrary.TileEngine;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class Player
    {
        #region Fields
        private Camera camera;
        private Game1 gameRef;
        private InputHandler input;
        private MovableSprite tank;
        #endregion

        #region Constructors
        public Player(Game game)
        {
            this.gameRef = (Game1)game;
            this.camera = new Camera(this.gameRef.ScreenRectangle);
        }
        #endregion

        #region Propeties
        public MovableSprite Tank
        {
            get
            {
                return this.tank;
            }

            set
            {
                this.tank = value;
            }
        }

        public Camera Camera
        {
            get
            {
                return this.camera;
            }

            set
            {
                this.camera = value;
            }
        }

        #endregion

        #region Methods
        public void Update(GameTime gameTime)
        {
            this.camera.Update(gameTime);
            this.tank.Update(gameTime);

            Matrix rotMatrix = new Matrix();
            Vector2 motion;

            if (InputHandler.IsKeyDown(Keys.W))
            {             
                this.tank.IsRotating = true;
                this.tank.Direction = Direction.Up;
                this.tank.Velocity = new Vector2(0, -1);
                rotMatrix = Matrix.CreateRotationZ(this.tank.RotationAngle);

            }
            else if (InputHandler.IsKeyDown(Keys.S))
            {                
                this.tank.IsRotating = true;
                this.tank.Direction = Direction.Down;
                this.tank.Velocity = new Vector2(0, 1);
                rotMatrix = Matrix.CreateRotationZ(this.tank.RotationAngle);
            }

            if (InputHandler.IsKeyDown(Keys.A))
            {
                this.tank.IsRotating = true;
                this.tank.Direction = Direction.Left;
                this.tank.Velocity = new Vector2(-1, 0);
                rotMatrix = Matrix.CreateRotationZ(this.tank.RotationAngle);
            }
            else if (InputHandler.IsKeyDown(Keys.D))
            {
                this.tank.IsRotating = true;
                this.tank.Direction = Direction.Right;
                this.tank.Velocity = new Vector2(1, 0);
                rotMatrix = Matrix.CreateRotationZ(this.tank.RotationAngle);
            }

            if (this.tank.IsRotating)
            {
                this.tank.Velocity.Normalize();
                motion = Vector2.Transform(this.tank.Velocity, rotMatrix);

                this.tank.Position += motion * this.tank.Speed;
                this.tank.LockToMap();

                if (this.camera.LockToPlayer)
                {
                    this.camera.LockCameraToPlayer(this.tank);
                }

                this.tank.IsRotating = false;
            }

            if (InputHandler.IsKeyReleased(Keys.F))
            {
                this.camera.ToggleCameraMode();
                if (this.camera.LockToPlayer)
                {
                    this.camera.LockCameraToPlayer(this.tank);
                }
            }

            if (this.camera.LockToPlayer)
            {
                if (InputHandler.IsKeyReleased(Keys.C))
                {
                    this.camera.LockCameraToPlayer(this.tank);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.tank.Draw(spriteBatch);
        }
        #endregion
    }
}
