namespace _01.KnapsackProblem
{
    public class Product
    {
        public Product(string name, int weight, int price)
        {
            this.Name = name;
            this.Weight = weight;
            this.Value = price;
        }

        public string Name { get; set; }

        public int Value { get; set; }

        public int Weight { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - weight: {1} cost: {2}", this.Name, this.Weight, this.Value);            
        }
    }
}
