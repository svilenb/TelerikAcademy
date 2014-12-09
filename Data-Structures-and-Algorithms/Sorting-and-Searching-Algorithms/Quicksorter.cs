namespace SortingHomework
{
    using System;
    using System.Collections.Generic;    

    public class QuickSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            QuickSortInPlace(collection, 0, collection.Count - 1);
        }

        private static void QuickSortInPlace(IList<T> collection, int leftIndex, int rightIndex)
        {
            if (collection.Count == 1)
            {
                return;
            }

            // (leftIndex + rightIndex) / 2--> may cause some bugs when working with big collections
            int i = leftIndex, j = rightIndex;
            int middleIndex = GetMiddle(leftIndex, rightIndex);

            //Choosing the pivot between more than one element is a good practice
            T pivot = ChoosePivot(collection[leftIndex], collection[middleIndex], collection[rightIndex]);

            while (i <= j)
            {
                while (collection[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (collection[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    T oldValue = collection[i];
                    collection[i] = collection[j];
                    collection[j] = oldValue;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
            {
                QuickSortInPlace(collection, leftIndex, j);
            }

            if (i < rightIndex)
            {
                QuickSortInPlace(collection, i, rightIndex);
            }
        }

        private static T ChoosePivot(T first, T second, T third)
        {
            //We choose the middle of three elements for pivot
            T pivot = default(T);

            if ((third.CompareTo(first) <= 0 && first.CompareTo(second) <= 0)
                || (second.CompareTo(first) <= 0 && first.CompareTo(third) <= 0))
            {
                pivot = first;
            }
            else if ((third.CompareTo(second) <= 0 && second.CompareTo(first) <= 0)
                || (first.CompareTo(second) <= 0 && second.CompareTo(third) <= 0))
            {
                pivot = second;
            }
            else if ((second.CompareTo(third) <= 0 && third.CompareTo(first) <= 0)
                || (first.CompareTo(third) <= 0 && third.CompareTo(second) <= 0))
            {
                pivot = third;
            }

            return pivot;
        }

        private static int GetMiddle(int leftPart, int rightPart)
        {
            double middle = (double)leftPart / 2 + (double)rightPart / 2;
            return (int)middle;
        }
    }
}
