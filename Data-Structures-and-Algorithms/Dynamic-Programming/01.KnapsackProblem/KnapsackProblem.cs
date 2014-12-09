namespace _01.KnapsackProblem
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class KnapsackProblem
    {
        private static List<Product> knapsack = new List<Product>();

        static void Main(string[] args)
        {
            int capacity = 10;
            var allProducts = new List<Product>()           
            {
                new Product("beer", 3, 2),
                new Product("vodka", 8, 12),
                new Product("cheese", 4, 5),
                new Product("nuts", 1, 4),
                new Product("ham", 2, 3),
                new Product("whiskey", 8, 13),
            };
            FindOptimalSolution(allProducts, capacity);
            Console.WriteLine("Best choice: ");
            Console.WriteLine(String.Join("\n", knapsack));
        }

        public static void FindOptimalSolution(IList<Product> products, int capacity)
        {
            int[,] valuesArray = new int[products.Count + 1, capacity + 1];
            int[,] keepArray = new int[products.Count + 1, capacity + 1];
            for (int i = 1; i <= products.Count; i++)
            {
                for (int k = 1; k <= capacity; k++)
                {
                    if (products[i - 1].Weight <= k)
                    {
                        int remainingSpace = (k) - products[i - 1].Weight;
                        if (remainingSpace > 0)
                        {
                            int valueAbove = valuesArray[i - 1, k - 1];
                            int sumValue = products[i - 1].Value + valuesArray[i - 1, remainingSpace - 1];
                            if (valueAbove > sumValue)
                            {
                                valuesArray[i, k] = valueAbove;
                                keepArray[i, k] = 0;
                            }
                            else
                            {
                                valuesArray[i, k] = sumValue;
                                keepArray[i, k] = 1;
                            }
                        }
                        else
                        {
                            valuesArray[i, k] = products[i - 1].Value;
                            keepArray[i, k] = 1;
                        }
                    }
                }
            }

            //PrintMatrix(valuesArray);
            //PrintMatrix(keepArray);

            int remainSpace = capacity;
            int item = products.Count;
            while (item >= 0 && remainSpace > 0)
            {
                int toBeAdded = keepArray[item, remainSpace - 1];
                if (toBeAdded == 1)
                {
                    knapsack.Add(products[item - 1]);
                    remainSpace -= products[item - 1].Weight;
                }

                item--;
            }
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(" {0} ", matrix[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}