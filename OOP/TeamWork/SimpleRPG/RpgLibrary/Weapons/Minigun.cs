using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankWars.Weapons
{
    public class Minigun : PrimaryWeapon
    {
        private const int MinigunDamage = 80;
        private const int MinigunSpeed = 6;

        public Minigun()
            : base(MinigunDamage, MinigunSpeed)
        {

        }
    }
}
