namespace WarMachines.Machines
{
    using System;
    using System.Text;
    using WarMachines.Interfaces;

    public class Fighter : Machine, IMachine, IFighter
    {
        private const int InitialHealthPoints = 200;

        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, Fighter.InitialHealthPoints, attackPoints, defensePoints)
        {
            this.StealthMode = stealthMode;
        }

        public bool StealthMode { get; private set; }

        public void ToggleStealthMode()
        {
            this.StealthMode = !this.StealthMode;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(base.ToString());
            result.AppendLine(string.Format(" *Stealth: {0}", this.StealthMode == true ? Machine.modeOn : Machine.modeOff));
            
            return result.ToString();
        }
    }
}
