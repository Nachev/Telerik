namespace FurnitureManufacturer.Models
{
    using System;
    using System.Linq;
    using System.Text;
    using FurnitureManufacturer.Interfaces;

    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private const decimal ConvertedHeight = 0.10M;
        private decimal normalHeight;

        public bool IsConverted { get; private set; }

        public ConvertibleChair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs) 
            : base(model, material, price, height, numberOfLegs)
        {
            this.normalHeight = this.Height;
        }

        public void Convert()
        {
            if (this.IsConverted)
            {
                this.Height = this.normalHeight;
            }
            else
            {
                this.Height = ConvertedHeight;
            }

            this.IsConverted = !this.IsConverted;
        }

        public override string ToString()
        {
            var result = new StringBuilder(base.ToString());
            result.AppendFormat(", State: {0}", this.IsConverted ? "Converted" : "Normal");
            return result.ToString();
        }
    }
}
