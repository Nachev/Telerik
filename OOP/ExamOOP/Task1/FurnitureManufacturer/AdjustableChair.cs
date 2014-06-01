namespace FurnitureManufacturer
{
    using System;
    using System.Linq;
    using FurnitureManufacturer.Interfaces;

    public class AdjustableChair : Chair, IAdjustableChair
    {
        private const decimal MinimalHeight = 0.0M;

        public AdjustableChair(string model, string material, decimal price, decimal height, int numberOfLegs) 
            : base(model, material, price, height, numberOfLegs)
        {
        }

        public void SetHeight(decimal height)
        {
            if (height < MinimalHeight)
            {
                throw new ArgumentException(string.Format("Height value cannot be less or equal to {0}.", MinimalHeight));
            }

            this.Height = height;
        }
    }
}
