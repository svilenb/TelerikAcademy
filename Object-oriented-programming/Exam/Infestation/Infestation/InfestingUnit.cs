namespace Infestation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class InfestingUnit : Unit
    {
        public InfestingUnit(string id, UnitClassification unitType, int health, int power, int aggression)
            : base(id, unitType, health, power, aggression)
        {
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            var theUnitToInfest = units.OrderByDescending(unit => unit.Health).FirstOrDefault(target => !target.Equals(this));

            if (theUnitToInfest.Id != null)
            {
                if (this.UnitClassification == InfestationRequirements.RequiredClassificationToInfest(theUnitToInfest.UnitClassification))
                {
                    return new Interaction(new UnitInfo(this), theUnitToInfest, InteractionType.Infest);
                }
            }

            return Interaction.PassiveInteraction;
        }
    }
}
