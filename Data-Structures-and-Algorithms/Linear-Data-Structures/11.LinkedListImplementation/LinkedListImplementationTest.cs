namespace _11.LinkedListImplementation
{
    using System;

    class LinkedListImplementationTest
    {
        static void Main(string[] args)
        {
            var linkedList = new LinkedList<int>();

            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(1);
            linkedList.Add(5);
            linkedList.AddFirst(6);

            Console.WriteLine(string.Join(", ", linkedList));
            Console.WriteLine("Count:" + linkedList.Count);
            linkedList.RemoveFirst();
            Console.WriteLine("Removing first item");
            Console.WriteLine(string.Join(", ", linkedList));
            Console.WriteLine("Count:" + linkedList.Count);
        }
    }
}
