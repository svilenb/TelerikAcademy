using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

class BunnyFactory
{
    static List<int> cages = new List<int>();
    static long cagesToTake = new long();

    static void Main()
    {
        ReadInput();

        ProcessCages();

        Console.Write(cages[0]);
        for (int i = 1; i < cages.Count; i++)
        {
            Console.Write(" {0}", cages[i]);
        }

        Console.WriteLine();
    }

    private static void ProcessCages()
    {
        int counter = 1;

        while (true)
        {
            if ((counter) > cages.Count) break; //!

            List<int> temp = new List<int>();
            StringBuilder sb = new StringBuilder();
            StringBuilder excluded = new StringBuilder();

            int numberOfCagesToProcess = new int();

            for (int i = 0; i < counter; i++)
            {
                numberOfCagesToProcess += cages[i];
            }

            if (counter + numberOfCagesToProcess > cages.Count) break;

            BigInteger sum = 0;
            BigInteger product = 1;

            for (int i = counter; i < numberOfCagesToProcess + counter; i++) //vqrno
            {
                sum += (BigInteger)cages[i];
                product *= (BigInteger)cages[i];
            }

            sb.Append(sum);
            sb.Append(product);

            for (int i = numberOfCagesToProcess + counter; i < cages.Count; i++)
            {
                sb.Append(cages[i]);
            }

            for (int j = 0; j < sb.Length; j++)
            {
                if (sb[j] != '0' && sb[j] != '1')
                {
                    excluded.Append(sb[j]);
                }
            }

            cages = new List<int>();

            for (int j = 0; j < excluded.Length; j++)
            {
                cages.Add(int.Parse(excluded[j].ToString()));
            }

            counter++;
        }
    }

    private static void ReadInput()
    {
        while (true)
        {
            string currentInput = Console.ReadLine();

            if (currentInput != "END")
            {
                cages.Add(int.Parse(currentInput));

            }
            else
            {
                break;
            }
        }
    }
}
