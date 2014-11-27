namespace OnlineMarket
{
    using System;

    public class Product : IComparable<Product>
    {
        public Product(string name, double price, string type)
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Type { get; set; }

        public int CompareTo(Product other)
        {
            if (this.Price != other.Price)
            {
                return this.Price.CompareTo(other.Price);
            }

            if (this.Name != other.Name)
            {
                return this.Name.CompareTo(other.Name);
            }

            return this.Type.CompareTo(other.Type);
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Price);
        }
    }
}
