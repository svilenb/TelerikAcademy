namespace Infestation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AggressionCatalyst : Supplement
    {
        private const int GeneralPowerEffect = 0;
        private const int GeneralHealthEffect = 0;
        private const int GeneralAggressionEffect = 3;

        public AggressionCatalyst()
            : base(AggressionCatalyst.GeneralPowerEffect, AggressionCatalyst.GeneralHealthEffect, AggressionCatalyst.GeneralAggressionEffect)
        {
        }
    }
}
