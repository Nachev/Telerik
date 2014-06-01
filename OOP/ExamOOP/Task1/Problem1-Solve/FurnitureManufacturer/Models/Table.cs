namespace FurnitureManufacturer.Models
{
    using System;
    using System.Linq;
    using System.Text;
    using FurnitureManufacturer.Interfaces;

    public class Table : Furnture, ITable
    {
        private decimal length;
        private decimal width;

        public Table(string model, MaterialType material, decimal price, decimal height, decimal length, decimal width) 
            : base(model, material, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Length
        {
            get 
            { 
                return this.length;
            }

            private set
            {
                if (value < 0M)
                {
                    throw new ArgumentException("Invalid value for length. Length cannot be less or equal to 0.00.");
                }

                this.length = value;
            }
        }

        public decimal Width
        {
            get 
            {
                return this.width; 
            }

            private set
            {
                if (value < 0M)
                {
                    throw new ArgumentException("Invalid value for width. Width cannot be less or equal to 0.00.");
                }

                this.width = value;
            }
        }

        public decimal Area
        {
            get 
            { 
                return this.Length * this.Width; 
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder(base.ToString());
            result.AppendFormat(", Length: {0}, Width: {1}, Area: {2}", this.Length, this.Width, this.Area);
            return result.ToString();
        } 
    }
}
