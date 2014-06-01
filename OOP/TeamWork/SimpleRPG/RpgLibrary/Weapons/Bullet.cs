namespace TankWars.Weapons
{
    public class Bullet
    {
        private int x;
        private int y;
        private int damage;
        private int shootSpeed;

        public Bullet(int x, int y, int damage, int shootSpeed)
        {
            this.X = x;
            this.Y = y;
            this.Damage = damage;
            this.ShootSpeed = shootSpeed;
        }

        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }
            set
            {
                this.damage = value;
            }
        }

        public int ShootSpeed
        {
            get
            {
                return this.shootSpeed;
            }
            set
            {
                this.shootSpeed = value;
            }
        }
    }
}
