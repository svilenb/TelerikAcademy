namespace Computers.Components
{
    using System.Collections.Generic;

    public class ServerComputer : Computer
    {
        public ServerComputer(Computers.Components.Cpu cpu, IEnumerable<HardDriver> hardDrives, Motherboard motherboard) : base(cpu, hardDrives, motherboard)
        {
        }

        public void Process(int data)
        {
            this.Motherboard.SaveRamValue(data);
            this.Cpu.SquareNumber();
        }
    }
}
