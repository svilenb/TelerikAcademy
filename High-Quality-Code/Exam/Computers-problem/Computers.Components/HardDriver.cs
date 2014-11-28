namespace Computers.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HardDriver
    {
        private bool isInRaid;
        private int hardDrivesInRaid;
        private List<HardDriver> harddrivers;
        private int capacity;
        private Dictionary<int, string> data;

        public HardDriver(int capacity, bool isInRaid, int hardDrivesInRaid)
        {
            this.isInRaid = isInRaid;
            this.hardDrivesInRaid = hardDrivesInRaid;
            this.capacity = capacity;
            this.data = new Dictionary<int, string>(capacity);
            this.harddrivers = new List<HardDriver>();
        }

        public HardDriver(int capacity, bool isInRaid, int hardDrivesInRaid, List<HardDriver> hardDrives)
        {
            this.isInRaid = isInRaid;
            this.hardDrivesInRaid = hardDrivesInRaid;
            this.capacity = capacity;
            this.data = new Dictionary<int, string>(capacity);
            this.harddrivers = new List<HardDriver>();
            this.harddrivers = hardDrives;
        }

        private int Capacity
        {
            get
            {
                if (this.isInRaid)
                {
                    if (!this.harddrivers.Any())
                    {
                        return 0;
                    }

                    return this.harddrivers.First().Capacity;
                }
                else
                {
                    return this.capacity;
                }
            }
        }

        public void SaveData(int addr, string newData)
        {
            if (this.isInRaid)
            {
                foreach (var hardDrive in this.harddrivers)
                {
                    hardDrive.SaveData(addr, newData);
                }
            }
            else
            {
                this.data[addr] = newData;
            }
        }

        public string LoadData(int address)
        {
            if (this.isInRaid)
            {
                if (!this.harddrivers.Any())
                {
                    throw new ArgumentException("No hard drive in the RAID array!");
                }

                return this.harddrivers.First().LoadData(address);
            }
            else if (true)
            {
                return this.data[address];
            }
        }
    }
}
