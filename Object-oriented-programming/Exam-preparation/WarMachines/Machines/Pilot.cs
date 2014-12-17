namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using WarMachines.Interfaces;

    public class Pilot : IPilot
    {
        private string name;
        private IList<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new ArgumentNullException("Machine added to pilot cannot be null");
            }
            this.machines.Add(machine);            
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            string numberOfMachines = this.machines.Count != 0 ? this.machines.Count().ToString() : "no";

            result.AppendLine(string.Format("{0} - {1} {2}", this.Name, numberOfMachines, this.machines.Count != 1 ? "machines" : "machine"));
         
            var sortedMachines = this.machines.OrderBy(machine => machine.HealthPoints).ThenBy(machine => machine.Name);

            foreach (var machine in this.machines)
            {
                result.Append(machine.ToString());
            }
            
            return result.ToString().TrimEnd();
        }
    }
}
