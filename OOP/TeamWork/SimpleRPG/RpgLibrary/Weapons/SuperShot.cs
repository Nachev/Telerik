using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankWars.Weapons
{
    public class SuperShot : SecondaryWeapon
    {
        private const int SupershotDamage = 50;
        private const int SupershotCharges = 3;
        private const int SupershotShootSpeed = 3;
        public SuperShot() : base(SupershotDamage, SupershotShootSpeed, SupershotCharges)
        {

        }
    }
}
