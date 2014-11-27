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
        private IList<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Company's name cannot be null");
                }

                if (value.Length < 5)
                {
                    throw new ArgumentException("Company name must be at least 5 symbols");
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Company's Registration number cannot be null");
                }

                if (value.Length != 10)
                {
                    throw new ArgumentException("Company's registration number must be exactly 10 symbols");
                }

                foreach (var item in value)
                {
                    if (!char.IsDigit(item))
                    {
                        throw new ArgumentException("Company's registration number must contaion only digits");
                    }
                }

                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return new List<IFurniture>(this.furnitures);
            }
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            foreach (var furniture in this.furnitures)
            {
                if (furniture.Model.ToLower() == model.ToLower())
                {
                    return furniture;
                }
            }

            return null;
        }

        public string Catalog()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(string.Format("{0} - {1} - {2} {3}", this.Name, this.RegistrationNumber, this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no", this.Furnitures.Count != 1 ? "furnitures" : "furniture"));

            var orderedFurnitures = this.Furnitures.OrderBy(furniture => furniture.Price).ThenBy(furniture => furniture.Model);

            if (this.Furnitures.Count != 0)
            {
                foreach (var item in orderedFurnitures)
                {
                    result.AppendLine(item.ToString());
                }
            }

            return result.ToString().TrimEnd();
        }
    }
}
