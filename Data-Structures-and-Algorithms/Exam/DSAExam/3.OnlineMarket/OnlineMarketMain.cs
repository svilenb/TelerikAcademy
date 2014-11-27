namespace OnlineMarket
{
    using System;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class OnlineMarketMain
    {
        private static OrderedBag<Product> products = new OrderedBag<Product>();
        private static Set<string> productNames = new Set<string>();
        private static OrderedDictionary<string, OrderedBag<Product>> typeProducts = new OrderedDictionary<string, OrderedBag<Product>>();

        public static void Main(string[] args)
        {
            string currentLine = Console.ReadLine();
            while (currentLine != "end")
            {
                ExecuteCommand(currentLine.Split());
                currentLine = Console.ReadLine();
            }
        }

        private static void ExecuteCommand(string[] command)
        {
            if (command[0] == "add")
            {
                if (!productNames.Contains(command[1]))
                {
                    var product = new Product(command[1], double.Parse(command[2]), command[3]);
                    products.Add(product);
                    productNames.Add(command[1]);

                    if (!typeProducts.ContainsKey(command[3]))
                    {
                        typeProducts.Add(command[3], new OrderedBag<Product>());
                    }

                    typeProducts[command[3]].Add(product);

                    Console.WriteLine("Ok: Product {0} added successfully", product.Name);
                }
                else
                {
                    Console.WriteLine("Error: Product {0} already exists", command[1]);
                }
            }
            else if (command[0] == "filter" && command.Length == 7)
            {
                var items = products.Where(x => x.Price >= double.Parse(command[4]) && x.Price <= double.Parse(command[6])).Take(10);
                if (items.Count() == 0)
                {
                    Console.WriteLine("Ok: ");
                }
                else
                {
                    Console.WriteLine("Ok: " + string.Join(", ", items));
                }
            }
            else if (command[0] == "filter" && command.Length == 5)
            {
                if (command[3] == "from")
                {
                    var items = products.Where(x => x.Price >= double.Parse(command[4])).Take(10);
                    if (items.Count() == 0)
                    {
                        Console.WriteLine("Ok: ");
                    }
                    else
                    {
                        Console.WriteLine("Ok: " + string.Join(", ", items));
                    }
                }
                else if (command[3] == "to")
                {
                    var items = products.Where(x => x.Price <= double.Parse(command[4])).Take(10);
                    if (items.Count() == 0)
                    {
                        Console.WriteLine("Ok: ");
                    }
                    else
                    {
                        Console.WriteLine("Ok: " + string.Join(", ", items));
                    }
                }
            }
            else if (command[0] == "filter" && command.Length == 4)
            {
                if (typeProducts.ContainsKey(command[3]))
                {
                    var items = typeProducts[command[3]].Take(10);
                    string output = string.Join(", ", items);
                    Console.WriteLine("Ok: " + output);
                }
                else
                {
                    Console.WriteLine("Error: Type {0} does not exists", command[3]);
                }
            }
        }
    }
}
