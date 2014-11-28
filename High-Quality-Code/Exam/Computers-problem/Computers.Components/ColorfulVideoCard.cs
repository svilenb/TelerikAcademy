namespace Computers.Components
{
    using System;

    public class ColorfulVideoCard : VideoCard
    {
        public override void Draw(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
