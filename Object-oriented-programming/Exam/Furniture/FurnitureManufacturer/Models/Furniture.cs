namespace FurnitureManufacturer.Models
{
    using System;
    using System.Text;
    using FurnitureManufacturer.Interfaces;

    public abstract class Furniture : IFurniture
    {
        private string model;
        private MaterialType materialType;
        private decimal price;
        private decimal height;

        public Furniture(string model, string materialType, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = materialType;
            this.Price = price;
            this.Height = height;
        }

        public Furniture(string model, MaterialType materialType, decimal price, decimal height)
        {
            this.Model = model;
            this.materialType = materialType;
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Furniture's model cannot be null or empty");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Furniture's model cannot be less than three symbols");
                }

                this.model = value;
            }
        }

        public string Material
        {
            get
            {
                return this.materialType.ToString();
            }

            private set
            {
                foreach (var materialType in (MaterialType[])Enum.GetValues(typeof(MaterialType)))
                {
                    if (materialType.ToString().ToLower() == value.ToLower())
                    {
                        this.materialType = materialType;
                    }
                }
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value <= 0M)
                {
                    throw new ArgumentException("Price cannot be less or equal to 0.00 dollars");
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
                if (value <= 0M)
                {
                    throw new ArgumentException("Height cannot be less or equal to 0.00 meters");
                }

                this.height = value;
            }
        }

        public override bool Equals(object obj)
        {
            Furniture passedFurniture = obj as Furniture;

            if (passedFurniture == null)
            {
                return false;
            }

            if (this.Model != passedFurniture.Model)
            {
                return false;
            }

            if (this.Material != passedFurniture.Material)
            {
                return false;
            }

            if (this.Price != passedFurniture.Price)
            {
                return false;
            }

            if (this.Height != passedFurniture.Height)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}", this.GetType().Name, this.Model, this.Material, this.Price, this.Height));

            return result.ToString();
        }
    }
}
