namespace FurnitureManufacturer.Models
{
    using System;
    using System.Text;

    using FurnitureManufacturer.Interfaces;

    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private const decimal ConvertedHeight = 0.10M;
        private readonly decimal initialHeight;

        public ConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
            this.IsConverted = false;
            this.initialHeight = height;
        }

        public bool IsConverted { get; private set; }

        public void Convert()
        {
            this.IsConverted = !this.IsConverted;

            if (this.IsConverted == true)
            {
                this.Height = ConvertibleChair.ConvertedHeight;
            }
            else
            {
                this.Height = this.initialHeight;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(base.ToString());
            result.Append(string.Format(", State: {0}", this.IsConverted ? "Converted" : "Normal"));

            return result.ToString();
        }
    }
}
