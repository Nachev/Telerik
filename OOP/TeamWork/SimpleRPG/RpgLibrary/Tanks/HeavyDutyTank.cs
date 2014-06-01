namespace TankWarsLibrary.Tanks
{
    using System;
    using TankWars.Common;

    public class HeavyDutyTank : Tank
    {
        // Heavy Tank with slow speed, a lot of armour, a lot of energy. Cannot swim and cannot have stealth mode.
        private const int SPEED = 20;
        private const int ARMOUR = 200;
        private const int HEALTH = 1000;
        private const int ENERGY = 500;

        public HeavyDutyTank(string name, ItemPosition position)
            : base(name, position, ARMOUR, ENERGY, HEALTH, SPEED)
        {

            //TODO: Initialize guns
        }        
    }
}
