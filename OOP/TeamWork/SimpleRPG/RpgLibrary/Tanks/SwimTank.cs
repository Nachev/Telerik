namespace TankWarsLibrary.Tanks
{
    using System;
    using System.Collections.Generic;
    using TankWars.Common;
    using TankWars.Tanks;
    using TankWars.Weapons;
    using TankWarsLibrary.Tanks;

    public class SwinTank : Tank, ISwim
    {
        // Swim Tank with regular speed, armour and energy. Can swim but cannot shoot from water.
        private const int SPEED = 50;
        private const int ARMOUR = 100;
        private const int HEALTH = 700;
        private const int ENERGY = 400;
        private const int SWIM_SPEED = 25;
        private const int MAX_OXIGEN = 50;

        private int oxigenLevel;

        public SwinTank(string name, ItemPosition position)
            : base(name, position, ARMOUR, ENERGY, HEALTH, SPEED)
        {
            this.SwimSpeed = SWIM_SPEED;
            this.IsSwimming = false;
            this.OxigenLevel = MAX_OXIGEN;
            //TODO: Initialize guns
        }

        public bool IsSwimming { get; set; }

        public int SwimSpeed { get; private set; }

        public int OxigenLevel
        {
            get
            {
                return this.oxigenLevel;
            }
            set
            {
                if (value < 0 || value > MAX_OXIGEN)
                {
                    throw new ArgumentException("Exigen cannot be negative or more than max!");
                }
                this.oxigenLevel = value;
            }
        }
    }
}
