namespace AStarPathfinding
{
    using Microsoft.Xna.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Camera
    {
        private const float DefaultSpeed = 4.0f;
        private const float MinimalSpeed = 0.5f;
        private const float MaximalSpeed = 25f;

        private Vector2 position;
        private float speed;

        public Camera()
        {
            this.position = new Vector2();
            this.speed = DefaultSpeed;
        }
        public Vector2 Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position.X = MathHelper.Clamp(value.X, 0, Map.MapWidthInPixels - Map.ScreenWidth);
                this.position.Y = MathHelper.Clamp(value.Y, 0, Map.MapHeightInPixels - Map.ScreecHeight);
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
                this.speed = MathHelper.Clamp(value, MinimalSpeed, MaximalSpeed);
            }
        }
    }
}
