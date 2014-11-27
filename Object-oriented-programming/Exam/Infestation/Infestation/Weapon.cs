namespace Infestation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Weapon : Supplement
    {
        private const int GeneralPowerEffect = 10;
        private const int GeneralAgressionIncrease = 3;

        public Weapon()
            : base()
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is WeaponrySkill)
            {
                this.PowerEffect = Weapon.GeneralPowerEffect;
                this.AggressionEffect = Weapon.GeneralAgressionIncrease;
            }
        }
    }
}
