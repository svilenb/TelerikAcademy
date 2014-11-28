namespace Computers.Components.Factories
{
    using System;

    public static class ComputerManufacturerFactory
    {
        public static ComputerManufacturer GetComputerManufacturer(string manufacturerName)
        {
            switch (manufacturerName)
            {
                case "HP":
                    return new HPManufacturer();
                case "Dell":
                    return new DellManufacturer();
                case "Lenovo":
                    return new LenovoManufacturer();
                default:
                    throw new ArgumentException("Invalid manufacturer!");
            }
        }
    }
}
