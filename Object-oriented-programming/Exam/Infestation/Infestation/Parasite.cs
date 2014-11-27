namespace Infestation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Parasite : InfestingUnit
    {
        public Parasite(string id)
            : base(id, UnitClassification.Biological, 1, 1, 1)
        {
        }        
    }
}
