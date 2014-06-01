namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FurnitureManufacturer.Interfaces;

    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> catalog;

        public Company(string initialName, string initRegistrationNumber)
        {
            this.Name = initialName;
            this.RegistrationNumber = initRegistrationNumber;
            this.catalog = new List<IFurniture>();
        }

        public string Name
        {
            get 
            {
                return this.name; 
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException("Invalid value for company name.");
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get 
            {
                return this.registrationNumber; 
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length != 10)
                {
                    if(value.Any(d => !char.IsDigit(d)))
                    {
                        throw new ArgumentException("Invalid value for company registration number.");
                    }
                }

                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get 
            { 
                return this.catalog; 
            }
        }

        public void Add(IFurniture furniture)
        {
            this.catalog.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.catalog.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            var result = this.catalog.FirstOrDefault(f => f.Model == model);
            return result;
        }

        public string Catalog()
        {
            var result = new StringBuilder();
            result.AppendFormat(
                "{0} - {1} - {2} {3}",
                this.Name,
                this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture"
                );

            foreach (var furniture in catalog)
            {
                result.AppendLine();
                result.Append(furniture);
            }

            return result.ToString();
        }
    }
}
