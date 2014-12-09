using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Sequence
{
    class Sequence
    {
        static void Main(string[] args)
        {
            int n = 2;
            int p = 50;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);

            Console.WriteLine("N = {0}", n);
            Console.WriteLine("P = {0}", p);
            Console.Write("S =");

            int index = 0;
            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                Console.Write(" {0}", current);
                index++;

                if (index == p)
                {
                    return;
                }

                queue.Enqueue(current + 1);
                queue.Enqueue(2 * current + 1);
                queue.Enqueue(current + 2);
            }
        }
    }
}
