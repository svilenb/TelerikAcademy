namespace Infestation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HealthCatalyst : Supplement, ISupplement
    {
        private const int GeneralPowerEffect = 0;
        private const int GeneralHealthEffect = 3;
        private const int GeneralAggressionEffect = 0;

        public HealthCatalyst()
            : base(HealthCatalyst.GeneralPowerEffect, HealthCatalyst.GeneralHealthEffect, HealthCatalyst.GeneralAggressionEffect)
        {
        }
    }
}
