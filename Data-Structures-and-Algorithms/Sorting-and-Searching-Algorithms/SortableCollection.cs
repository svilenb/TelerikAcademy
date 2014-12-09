namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (this.items[i].CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int startIndex = 0;
            int endIndex = this.items.Count - 1;
            int currentIndex = -1;

            currentIndex = GetMiddle(startIndex, endIndex);            
            do
            {
                if (this.items[currentIndex].Equals(item))
                {
                    return true;
                }
                else if (this.items[currentIndex].CompareTo(item) > 0)
                {
                    endIndex = currentIndex - 1;
                    currentIndex = GetMiddle(startIndex, endIndex);

                }
                else if (this.items[currentIndex].CompareTo(item) < 0)
                {
                    startIndex = currentIndex + 1;
                    currentIndex = GetMiddle(startIndex, endIndex);
                }
            } while (startIndex <= endIndex);

            return false;
        }

        /// <summary>
        /// Method for shuffling using algorithm with O(n) complexity.
        /// </summary>
        public void Shuffle()
        {
            Random ran = new Random();
            for (var i = 0; i < this.items.Count; i++)
            {
                int randomIndex = i + ran.Next(0, this.items.Count - i);
                T oldValue = this.items[i];
                this.items[i] = this.items[randomIndex];
                this.items[randomIndex] = oldValue;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }

        private static int GetMiddle(int leftPart, int rightPart)
        {
            double middle = (double)leftPart / 2 + (double)rightPart / 2;
            return (int)middle;
        }
    }
}
