namespace Computers.Components
{
    public class RAM
    {
        public RAM(int amount)
        {
            this.Amount = amount;
        }

        public int Amount { get; private set; }

        private int Value { get; set; }

        public void SaveValue(int newValue)
        {
            this.Value = newValue;
        }

        public int LoadValue()
        {
            return this.Value;
        }
    }
}
