namespace FindProductsInPriceRange
{
    using System;

    public class Product : IComparable
    {
        private string name;
        private double price;

        public Product(string name, double price)
        {
            this.name = name;
            this.price = price;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("name", "The name of the product cannot be null or whitespace!");
                }

                this.name = value;
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("price", "The price of the product has to be positive!");
                }

                this.price = value;
            }
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Product otherProduct = obj as Product;
            if (otherProduct != null)
            {
                return this.Price.CompareTo(otherProduct.Price);
            }
            else
            {
                throw new ArgumentException("Object is not a Product");
            }
        }
    }
}
