namespace FurnitureManufacturer.Models
{
    using System;
    using System.Text;

    using FurnitureManufacturer.Interfaces;

    public class Table : Furniture, ITable
    {
        public Table(string model, string materialType, decimal price, decimal height, decimal length, decimal width)
            : base(model, materialType, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Length { get; private set; }

        public decimal Width { get; private set; }

        public decimal Area
        {
            get
            {
                return this.Length * this.Width;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(base.ToString());
            result.Append(string.Format(", Length: {0}, Width: {1}, Area: {2}", this.Length, this.Width, this.Area));

            return result.ToString();
        }
    }
}
