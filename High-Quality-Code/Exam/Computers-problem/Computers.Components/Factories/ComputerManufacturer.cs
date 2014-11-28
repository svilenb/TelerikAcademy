namespace Computers.Components.Factories
{
    using Components;

    public abstract class ComputerManufacturer
    {
        public abstract PCComputer MakePC();

        public abstract LaptopComputer MakeLaptop();

        public abstract ServerComputer MakeServer();
    }
}
