namespace Computers.Components.Factories
{
    using System.Collections.Generic;
    using Components;

    public class DellManufacturer : ComputerManufacturer
    {
        public override PCComputer MakePC()
        {
            var ram = new RAM(8);
            var videoCard = new ColorfulVideoCard();
            var motherboard = new Motherboard(ram, videoCard);
            var hardDrivers = new[] { new HardDriver(1000, false, 0) };
            return new PCComputer(new Cpu64Bit(4, motherboard, StandardRandomNumbersProvider.Instance), hardDrivers, motherboard);
        }

        public override ServerComputer MakeServer()
        {
            var ram = new RAM(64);
            var videoCard = new MonochromeVideoCard();
            var motherboard = new Motherboard(ram, videoCard);
            var hardDrivers = new List<HardDriver>
                    {
                        new HardDriver(0, true, 2, new List<HardDriver> { new HardDriver(2000, false, 0), new HardDriver(2000, false, 0) })
                    };

            return new ServerComputer(new Cpu64Bit(8, motherboard, StandardRandomNumbersProvider.Instance), hardDrivers, motherboard);
        }

        public override LaptopComputer MakeLaptop()
        {
            var ram = new RAM(8);
            var videoCard = new ColorfulVideoCard();
            var motherboard = new Motherboard(ram, videoCard);
            var hardDrivers = new[] { new HardDriver(1000, false, 0) };
            return new LaptopComputer(new Cpu32Bit(4, motherboard, StandardRandomNumbersProvider.Instance), hardDrivers, motherboard, new LaptopBattery());
        }
    }
}
