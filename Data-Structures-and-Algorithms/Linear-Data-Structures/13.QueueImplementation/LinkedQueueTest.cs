namespace _13.QueueImplementation
{
    using System;

    class LinkedQueueTest
    {
        static void Main(string[] args)
        {
            var queue = new LinkedQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(7);
            Console.WriteLine("Count: " + queue.Count);
            Console.WriteLine(string.Join(", ", queue));            
            Console.WriteLine("Removed item: {0}", queue.Dequeue()); 
            Console.WriteLine("Count: " + queue.Count);
            Console.WriteLine(string.Join(", ", queue));
            Console.WriteLine("Clearing queue");
            queue.Clear();
            Console.WriteLine(string.Join(", ", queue));            
        }
    }
}
