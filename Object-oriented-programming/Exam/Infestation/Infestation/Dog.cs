namespace Infestation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Dog : Unit
    {
        private const int DogPower = 5;
        private const int DogAggression = 2;
        private const int DogHealth = 4;

        public Dog(string id) :
            base(id, UnitClassification.Biological, Dog.DogHealth, Dog.DogPower, Dog.DogAggression)
        {
        }
    }
}
