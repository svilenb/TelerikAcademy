namespace WarMachines.Machines
{
    using System;
    using System.Text;
    using WarMachines.Interfaces;

    public class Tank : Machine, ITank, IMachine
    {
        private const int InitialHealthPoints = 100;
        private const int DefModeDefPointsBonus = 30;
        private const int DefModeAttackPointsPenalty = 40;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, Tank.InitialHealthPoints, attackPoints, defensePoints)
        {
            this.DefenseMode = false;
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            this.DefenseMode = !this.DefenseMode;

            if (this.DefenseMode == true)
            {
                this.DefensePoints += DefModeDefPointsBonus;
                this.AttackPoints -= DefModeAttackPointsPenalty;
            }
            else
            {
                this.DefensePoints -= DefModeDefPointsBonus;
                this.AttackPoints += DefModeAttackPointsPenalty;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(base.ToString());
            result.AppendLine(string.Format(" *Defense: {0}", this.DefenseMode == true ? Machine.modeOn : Machine.modeOff));
            
            return result.ToString();
        }
    }
}
