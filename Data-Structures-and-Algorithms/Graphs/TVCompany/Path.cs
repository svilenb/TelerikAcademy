namespace TVCompany
{
    using System;

    public class Path : IComparable<Path>
    {
        public Path(int startHouse, int endHouse, int weight)
        {
            this.StartHouse = startHouse;
            this.EndHouse = endHouse;
            this.WireLength = weight;
        }

        public int StartHouse { get; set; }

        public int EndHouse { get; set; }

        public int WireLength { get; set; }

        public int CompareTo(Path other)
        {
            int weightCompared = this.WireLength.CompareTo(other.WireLength);

            if (weightCompared == 0)
            {
                return this.StartHouse.CompareTo(other.StartHouse);
            }

            return weightCompared;
        }

        public override string ToString()
        {
            return string.Format("({0} {1}) -> {2}", this.StartHouse, this.EndHouse, this.WireLength);
        }
    }
}
