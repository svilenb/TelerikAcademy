namespace Computers.Components
{
    using System;

    public abstract class Cpu
    {
        protected const int Minvalue = 0;

        public Cpu(byte numberOfCores, Motherboard motherboard, IRandomNumbersProvider randomProvider)
        {
            this.MotherBoard = motherboard;
            this.NumberOfCores = numberOfCores;
            this.RandomProvider = randomProvider;
        }

        public byte NumberOfCores { get; private set; }

        protected Motherboard MotherBoard { get; set; }

        protected IRandomNumbersProvider RandomProvider { get; set; }

        public void SquareNumber()
        {
            var data = this.MotherBoard.LoadRamValue();
            if (data < Minvalue)
            {
                this.MotherBoard.DrawOnVideoCard("Number too low.");
            }
            else if (data > this.GetMaxValue())
            {
                this.MotherBoard.DrawOnVideoCard("Number too high.");
            }
            else
            {
                int value = data * data;
                this.MotherBoard.DrawOnVideoCard(string.Format("Square of {0} is {1}.", data, value));
            }
        }

        public abstract int GetMaxValue();

        public void GenerateRandomNumber(int minValue, int maxValue)
        {
            int randomNumber;
            randomNumber = this.RandomProvider.GetRandomNumber(minValue, maxValue);
            this.MotherBoard.SaveRamValue(randomNumber);
        }
    }
}