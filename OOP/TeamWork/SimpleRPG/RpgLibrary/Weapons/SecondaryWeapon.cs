namespace TankWars.Weapons
{
    using System;
    using System.Collections.Generic;

    public class SecondaryWeapon : Weapon
    {
        int charges;
        public SecondaryWeapon(int damage, int shootSpeed, int charges)
            : base(damage, shootSpeed)
        {
            this.Charges = charges;
        }

        public int Charges
        {
            get
            {
                return this.charges;
            }
            set
            {
                this.charges = value;
            }
        }
        public IEnumerable<Bullet> Shoot()
        {
            //if charges > 0 shoot else do nothing
            //create bullets with the weapon damage, speed and coords of the tank/machine
            throw new NotImplementedException();
        }

    }
}
