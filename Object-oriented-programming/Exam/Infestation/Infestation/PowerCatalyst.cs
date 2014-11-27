namespace Infestation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PowerCatalyst : Supplement, ISupplement
    {
        private const int GeneralPowerEffect = 3;
        private const int GeneralHealthEffect = 0;
        private const int GeneralAggressionEffect = 0;

        public PowerCatalyst()
            : base(PowerCatalyst.GeneralPowerEffect, PowerCatalyst.GeneralHealthEffect, PowerCatalyst.GeneralAggressionEffect)
        {
        }
    }
}
