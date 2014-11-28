namespace Computers.Components
{
    using System;
    using System.Collections.Generic;

    public class LaptopComputer : Computer
    {
        private readonly LaptopBattery battery;

        public LaptopComputer(Computers.Components.Cpu cpu, IEnumerable<HardDriver> hardDrives, Motherboard motherboard, LaptopBattery battery) : base(cpu, hardDrives, motherboard)
        {
            this.battery = battery;
        }

        public void ChargeBattery(int percentage)
        {
            this.battery.Charge(percentage);
            this.Motherboard.DrawOnVideoCard(string.Format("Battery status: {0}%", this.battery.Percentage));
        }
    }
}
