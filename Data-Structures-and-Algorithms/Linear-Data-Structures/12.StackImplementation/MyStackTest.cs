namespace _12.StackImplementation
{
    using System;    

    class MyStackTest
    {
        static void Main(string[] args)
        {
            var stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);            
            Console.WriteLine(string.Join(", ", stack));
            Console.WriteLine("Popped value {0}", stack.Pop());
            Console.WriteLine(string.Join(", ", stack));
            Console.WriteLine("Stack contains 3 -> {0}", stack.Contains(3));
            Console.WriteLine("Clearing stack");
            stack.Clear();
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
