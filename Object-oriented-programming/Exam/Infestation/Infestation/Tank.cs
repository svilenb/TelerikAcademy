namespace Infestation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tank : Unit
    {
        private const int GeneralHealth = 20;
        private const int GeneralPower = 25;
        private const int GeneralAgression = 25;

        public Tank(string id)
            : base(id, UnitClassification.Mechanical, Tank.GeneralHealth, Tank.GeneralPower, Tank.GeneralAgression)
        {
        }
    }
}
