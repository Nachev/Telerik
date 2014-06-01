namespace FurnitureManufacturer
{
    using FurnitureManufacturer.Interfaces;
    using FurnitureManufacturer.Models;
    using System;
    using System.Linq;
    using System.Text;

    public class Chair : Furnture, IChair
    {
        private const int MinimalNumberOfLegs = 0;
        private int numberOfLegs;

        public Chair(string model, string material, decimal price, decimal height, int numberOfLegs) 
            : base(model, material, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get
            {
                return this.numberOfLegs;
            }

            private set
            {
                if (numberOfLegs < MinimalNumberOfLegs)
                {
                    throw new ArgumentException(string.Format("Number of legs value must be higher than {0}.", MinimalNumberOfLegs));
                }

                this.numberOfLegs = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder(base.ToString());
            result.AppendFormat(", Legs: {0}", this.NumberOfLegs);
            return result.ToString();
        }
    }
}
