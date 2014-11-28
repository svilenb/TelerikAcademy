namespace Computers.Components.Factories
{
    using System.Collections.Generic;
    using Components;

    public class LenovoManufacturer : ComputerManufacturer
    {
        public override PCComputer MakePC()
        {
            var ram = new RAM(4);
            var videoCard = new MonochromeVideoCard();
            var hardDrivers = new[] { new HardDriver(2000, false, 0) };
            var motherboard = new Motherboard(ram, videoCard);
            return new PCComputer(new Cpu64Bit(2, motherboard, StandardRandomNumbersProvider.Instance), hardDrivers, motherboard);
        }

        public override LaptopComputer MakeLaptop()
        {
            var videoCard = new ColorfulVideoCard();
            var ram = new RAM(16);
            var motherboard = new Motherboard(ram, videoCard);
            var cpu = new Cpu64Bit(2, motherboard, StandardRandomNumbersProvider.Instance);
            var laptopHardDrivers = new[] { new HardDriver(1000, false, 0) };

            return new LaptopComputer(cpu, laptopHardDrivers, motherboard, new LaptopBattery());
        }

        public override ServerComputer MakeServer()
        {
            var ram = new RAM(8);
            var videoCard = new MonochromeVideoCard();
            var motherboard = new Motherboard(ram, videoCard);
            var cpu = new Cpu128Bit(2, motherboard, StandardRandomNumbersProvider.Instance);
            var hardDrivers = new List<HardDriver> 
                    {
                        new HardDriver(0, true, 2, new List<HardDriver> { new HardDriver(500, false, 0), new HardDriver(500, false, 0) })
                    };

            return new ServerComputer(cpu, hardDrivers, motherboard);
        }
    }
}
