namespace Computers.Components
{
    using System;

    public class MonochromeVideoCard : VideoCard
    {
        public override void Draw(string message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
