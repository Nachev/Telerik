namespace TankWarsLibrary.Tanks
{
    using System;
    using System.Collections.Generic;
    using TankWars.Common;
    using TankWars.Tanks;
    using TankWars.Weapons;
    using TankWarsLibrary.Common;

    public abstract class Tank : Machine
    {
         
        // Default is Attack mode where tank can move and shoot. 
        // Defence mode means tank cannot shoot, but gets extra armour.
        private TankModeEnum mode;

        public Tank (string name, ItemPosition position, int armour, int energy, int health, int speed)
            : base(name, position)
        {
            this.Mode = TankModeEnum.Attack;
            this.InitialEnergy = energy;
            this.Armour = armour;
            this.Energy = this.InitialEnergy;
            this.Health = health;
            this.Speed = speed;
        }

        public int InitialEnergy { get; protected set; }

        public PrimaryWeapon PrimaryGun { get; protected set;}

        public SecondaryWeapon SpecialGun { get; protected set; }


        public TankModeEnum Mode
        {
            get
            {
                return this.mode;
            }
            set
            {
                if (this.Energy > (InitialEnergy / 5))   // cannot change tank mode if energy is below 20%
                {
                    this.mode = value;
                }
            }
        }

        // shoot with primary gun
        public IEnumerable <Bullet> ShootPrimaryGum()
        {
            return this.PrimaryGun.Shoot();
        }

        // shoot with special gun
        public IEnumerable<Bullet> ShootSpecialGum()
        {
            return this.SpecialGun.Shoot();
        }

        // primary gun does not take any energy but still needs to recharge.
        public void RechargePrimaryWeapon()
        {
            throw new NotImplementedException();
        }

        // this method will recharge the SpecualGun аnd will take some of the tank's energy.
        // Can be overrrided by every tank
        public virtual void RechargeSecondaryWeapon()
        {
            this.Energy -= (InitialEnergy / 5);
        }

        // this method should calculate total demage of tank
        public int CalculateTotalDemage()
        {
            return this.PrimaryGun.Damage + this.SpecialGun.Damage;
        }
    }
}
