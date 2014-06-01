namespace TankWarsLibrary.Common
{
    using System;
    using TankWars.Common;

    public abstract class Machine : IMovable
    {
        private string name;

        private ItemPosition position;

        private int armour;

        private int energy;

        private int health;

        public Machine(string name, ItemPosition position)
        {
            this.Name = name;
            this.position = position;
        }

        public ItemPosition Position
        {
            get
            {
                return this.position;
            }
            
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name of Machine cannot be empty!");
                }

                this.name = value;
            }
        }

        // adds durability to the machine. Reduce the damage taken by other units.
        public int Armour
        {
            get
            {
                return this.armour;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Machine armour cannot be negative number!");
                }

                this.armour = value;
            }
        }

        // determines how fast the machine can shoot or move.
        public int Energy
        {
            get
            {
                return this.energy;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Machine energy cannot be negative number!");
                }

                this.energy = value;
            }
        }

        // machine dies when health reaches 0.
        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Machine health cannot be negative number!");
                }

                this.health = value;
            }
        }

        // each machine implements it own speed
        public int Speed { get; protected set; }

        // machine changes position oly with this method.
        public virtual void Move(int x, int y)
        {
            this.position.X += x;
            this.position.Y += y;
            //this.Position = new ItemPosition(this.Position.X + x, this.Position.Y + y);   //Optional if property Set is used.
        }

    }
}
