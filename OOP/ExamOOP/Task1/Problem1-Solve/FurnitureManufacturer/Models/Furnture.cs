namespace FurnitureManufacturer.Models
{
    using System;
    using System.Linq;
    using System.Text;
    using FurnitureManufacturer.Interfaces;

    public abstract class Furnture : IFurniture
    {
        private string model;
        private decimal price;
        private decimal height;

        protected Furnture(string model, MaterialType material, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = material.ToString();
            this.Price = price;
            this.Height = height;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentException("Invalid value for model name.");
                }

                this.model = value;
            }
        }

        public string Material { get; private set; }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0M)
                {
                    throw new ArgumentException("Invalid value for price. Price cannot be less or equal to 0.00.");
                }

                this.price = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                if (value < 0M)
                {
                    throw new ArgumentException("Invalid value for height. Height cannot be less or equal to 0.00.");
                }

                this.height = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendFormat("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}",
                this.GetType().Name,
                this.Model,
                this.Material,
                this.Price,
                this.Height);

            return result.ToString();
        }
    }
}
