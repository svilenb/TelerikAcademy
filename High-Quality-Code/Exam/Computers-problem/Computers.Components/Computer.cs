namespace Computers.Components
{
    using System;
    using System.Collections.Generic;

    public abstract class Computer
    {
        public Computer(Cpu cpu, IEnumerable<HardDriver> hardDrives, Motherboard motherboard)
        {
            this.Cpu = cpu;
            this.HardDrives = hardDrives;
            this.Motherboard = motherboard;
        }

        public IEnumerable<HardDriver> HardDrives { get; set; }

        public Cpu Cpu { get; set; }

        public Motherboard Motherboard { get; private set; }
    }
}
