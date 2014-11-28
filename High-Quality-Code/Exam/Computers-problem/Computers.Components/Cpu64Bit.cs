namespace Computers.Components
{    
    public class Cpu64Bit : Computers.Components.Cpu
    {
        private const int MaxValue = 1000;

        public Cpu64Bit(byte numberOfCores, Motherboard motherboard, IRandomNumbersProvider randomNumbersProvider)
            : base(numberOfCores, motherboard, randomNumbersProvider)
        {
        }

        public override int GetMaxValue()
        {
            return MaxValue;
        }
    }
}
