namespace Computers.Components
{
    public class Cpu32Bit : Cpu
    {
        private const int MaxValue = 500;

        public Cpu32Bit(byte numberOfCores, Motherboard motherboard, IRandomNumbersProvider randomNumbersProvider)
            : base(numberOfCores, motherboard, randomNumbersProvider)
        {
        }

        public override int GetMaxValue()
        {
            return MaxValue;
        }
    }
}
