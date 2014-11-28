namespace Computers.UI.Console
{
    using System;

    using Computers.Components;
    using Computers.Components.Factories;

    public class ComputersEntry
    {
        private const string ChargeCommandName = "Charge";
        private const string ProcessCommandName = "Process";
        private const string PLayCommandName = "Play";

        public static void Main()
        {
            var manufacturerName = Console.ReadLine();
            var manufacturer = ComputerManufacturerFactory.GetComputerManufacturer(manufacturerName);
            var pc = manufacturer.MakePC();
            var laptop = manufacturer.MakeLaptop();
            var server = manufacturer.MakeServer();

            while (true)
            {
                var inputLIne = Console.ReadLine();
                if (inputLIne == null || inputLIne.StartsWith("Exit"))
                {
                    break;
                }

                var commandParameters = inputLIne.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (commandParameters.Length != 2)
                {
                    throw new ArgumentException("Invalid command!");
                }

                var commandName = commandParameters[0];
                var commandArguments = int.Parse(commandParameters[1]);

                if (commandName == ChargeCommandName)
                {
                    laptop.ChargeBattery(commandArguments);
                }
                else if (commandName == ProcessCommandName)
                {
                    server.Process(commandArguments);
                }
                else if (commandName == PLayCommandName)
                {
                    pc.Play(commandArguments);
                }
                else
                {
                    Console.WriteLine("Invalid command!");
                }
            }
        }
    }
}