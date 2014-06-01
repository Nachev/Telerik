namespace TankWars.Weapons
{
    public abstract class Weapon : IShootSpeed
    {
        private int damage;
        private int shootSpeed;

        public Weapon(int damage, int shootSpeed)
        {
            this.Damage = damage;
            this.ShootSpeed = shootSpeed;
        }

        // weapon demage
        public int Damage
        {
            get { return this.damage; }
            protected set { this.damage = value; }
        }

        public int ShootSpeed
        {
             get { return this.shootSpeed; }
            protected set { this.shootSpeed = value; }
        }
        
    }
}
