namespace Computers.Components
{
    public class LaptopBattery
    {
        private const int MaxPercentage = 100;
        private const int MinPercentage = 0;
        private int percentage;

        public LaptopBattery()
        {
            this.Percentage = 100 / 2;
        }

        public int Percentage
        {
            get
            {
                return this.percentage;
            }

            private set
            {
                if (value > 100)
                {
                    this.percentage = MaxPercentage;
                }
                else if (value < 0)
                {
                    this.percentage = MinPercentage;
                }
                else
                {
                    this.percentage = value;
                }
            }
        }

        public void Charge(int chargePercents)
        {
            this.Percentage += chargePercents;
        }
    }
}
