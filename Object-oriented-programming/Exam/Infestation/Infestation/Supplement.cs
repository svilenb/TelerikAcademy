namespace Infestation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Supplement : ISupplement
    {
        public Supplement()
        {
            this.PowerEffect = 0;
            this.HealthEffect = 0;
            this.AggressionEffect = 0;
        }

        public Supplement(int powerEffect, int healthEffect, int agressioneffect)
        {
            this.HealthEffect = healthEffect;
            this.PowerEffect = powerEffect;
            this.AggressionEffect = agressioneffect;
        }

        public int HealthEffect { get; protected set; }

        public int AggressionEffect { get; protected set; }

        public int PowerEffect { get; protected set; }

        public virtual void ReactTo(ISupplement otherSupplement)
        {
        }
    }
}
