namespace Computers.Components
{
    public class Cpu128Bit : Cpu
    {
        private const int MaxValue = 2000;

        public Cpu128Bit(byte numberOfCores, Motherboard motherboard, IRandomNumbersProvider randomNumbersProvider)
            : base(numberOfCores, motherboard, randomNumbersProvider)
        {
        }

        public override int GetMaxValue()
        {
            return MaxValue;
        }
    }
}
