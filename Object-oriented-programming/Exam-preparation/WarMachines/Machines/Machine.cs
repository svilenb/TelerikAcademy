namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WarMachines.Interfaces;

    public abstract class Machine : IMachine
    {
        public const string modeOn = "ON";
        public const string modeOff = "OFF";

        private string name;
        private IPilot pilot;
        private IList<string> targets;

        public Machine(string name, double healthPoints, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.targets = new List<string>();
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
                    throw new ArgumentNullException("Machine name cannot be null");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Pilot cannot be null");
                }

                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets
        {
            get
            {
                return new List<string>(this.targets);
            }
        }

        public void Attack(string target)
        {
            this.targets.Add(target);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(string.Format("- {0}", this.Name));
            result.AppendLine(string.Format(" *Type: {0}", this.GetType().Name));
            result.AppendLine(string.Format(" *Health: {0}", this.HealthPoints));
            result.AppendLine(string.Format(" *Attack: {0}", this.AttackPoints));
            result.AppendLine(string.Format(" *Defense: {0}", this.DefensePoints));

            string targetsString;
            if (this.targets.Count != 0)
                targetsString = string.Join(", ", this.targets);
            else
                targetsString = "None";
            result.AppendLine(string.Format(" *Targets: {0}", targetsString));

            return result.ToString();
        }
    }
}
