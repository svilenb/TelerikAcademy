namespace Infestation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Marine : Human
    {
        public Marine(string id)
            : base(id)
        {
            this.AddSupplement(new WeaponrySkill());
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, 0, int.MaxValue, 0);

            List<UnitInfo> withLowerPower = new List<UnitInfo>();

            optimalAttackableUnit = attackableUnits.OrderBy(target => target.Health).FirstOrDefault(target => target.Power <= this.Aggression);

            return optimalAttackableUnit;
        }
    }
}
