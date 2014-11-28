namespace Computers.Components
{
    public class Motherboard : IMotherboard
    {
        private RAM ram;
        private VideoCard videoCard;        

        public Motherboard(RAM ram, VideoCard videoCard)
        {
            this.Ram = ram;
            this.VideoCard = videoCard;
        }

        public RAM Ram
        {
            get
            {
                return this.ram;
            }

            set
            {
                this.ram = value;
            }
        }

        public VideoCard VideoCard
        {
            get
            {
                return this.videoCard;
            }

            set
            {
                this.videoCard = value;
            }
        }

        public int LoadRamValue()
        {
            return this.Ram.LoadValue();
        }

        public void SaveRamValue(int value)
        {
            this.Ram.SaveValue(value);
        }

        public void DrawOnVideoCard(string data)
        {
            this.VideoCard.Draw(data);
        }
    }
}
