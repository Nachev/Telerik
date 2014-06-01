namespace TankWars.Weapons
{
    using System;
    using System.Collections.Generic;
    public class PrimaryWeapon : Weapon
    {
        public PrimaryWeapon(int damage, int shootSpeed)
            : base(damage, shootSpeed)
        {

        }

        public IEnumerable<Bullet> Shoot()
        {
            //create bullets with the weapon damage, speed and coords of the tank/machine
            throw new NotImplementedException("Shoot not implemented!");
        }
    }
}
