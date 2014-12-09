namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                int smallestElementIndex = i;

                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[smallestElementIndex].CompareTo(collection[j]) > 0)
                    {
                        smallestElementIndex = j;
                    }
                }

                T oldValue = collection[i];
                collection[i] = collection[smallestElementIndex];
                collection[smallestElementIndex] = oldValue;
            }
        }
    }
}
