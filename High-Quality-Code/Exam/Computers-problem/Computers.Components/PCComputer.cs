namespace Computers.Components
{
    using System.Collections.Generic;

    public class PCComputer : Computer
    {
        public PCComputer(Computers.Components.Cpu cpu, IEnumerable<HardDriver> hardDrives, Motherboard motherboard)
            : base(cpu, hardDrives, motherboard)
        {
        }

        public void Play(int guessNumber)
        {
            Cpu.GenerateRandomNumber(1, 10);
            var number = this.Motherboard.LoadRamValue();
            if (number != guessNumber)
            {
                this.Motherboard.DrawOnVideoCard(string.Format("You didn't guess the number {0}.", number));
            }
            else
            {
                this.Motherboard.DrawOnVideoCard("You win!");
            }
        }
    }
}
