namespace GirlsGoneWild
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GirlsGoneWildMain
    {
        private static int[] shirts;
        private static char[] skirts;
        private static string skirtsInput;
        private static int girls;
        private static bool[] usedShirts;
        private static bool[] usedSkirts;
        private static int k;
        private static int numberOfWays = 0;
        private static SortedSet<string> output;

        public static void Main(string[] args)
        {
            k = int.Parse(Console.ReadLine());
            skirtsInput = Console.ReadLine();
            girls = int.Parse(Console.ReadLine());

            usedShirts = new bool[k];
            usedSkirts = new bool[skirtsInput.Length];
            shirts = new int[girls];
            skirts = new char[girls];

            output = new SortedSet<string>();
            GenerateVariationShirts(0, 0);
            Console.WriteLine(output.Count);
            foreach (var item in output)
            {
                Console.WriteLine(item);
            }
        }

        private static void GenerateVariationShirts(int index, int start)
        {
            if (index >= girls)
            {
                GenerateVariationSkirts(0);
            }
            else
            {
                for (int i = start; i < k; i++)
                {
                    shirts[index] = i;
                    GenerateVariationShirts(index + 1, i + 1);
                }
            }
        }

        private static void GenerateVariationSkirts(int index)
        {
            if (index >= girls)
            {
                string[] outputPart = new string[girls];
                for (int i = 0; i < girls; i++)
                {
                    outputPart[i] = string.Format("{0}{1}", shirts[i], skirts[i]);
                }

                numberOfWays++;
                output.Add(string.Join("-", outputPart));
            }
            else
            {
                for (int i = 0; i < skirtsInput.Length; i++)
                {
                    if (!usedSkirts[i])
                    {
                        usedSkirts[i] = true;
                        skirts[index] = skirtsInput[i];
                        GenerateVariationSkirts(index + 1);
                        usedSkirts[i] = false;
                    }
                }
            }
        }
    }
}
