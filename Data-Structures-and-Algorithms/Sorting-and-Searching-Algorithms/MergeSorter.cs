namespace SortingHomework
{
    using System;
    using System.Collections.Generic;    

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            MergeSort(collection);
        }

        private static void MergeSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return;
            }

            int middle = collection.Count / 2;
            T[] leftArray = new T[middle];
            T[] rightArray = new T[collection.Count - middle];

            for (int i = 0; i < middle; i++)
            {
                leftArray[i] = collection[i];
            }

            for (int i = middle, j = 0; i < collection.Count; i++, j++)
            {
                rightArray[j] = collection[i];
            }

            MergeSort(leftArray);
            MergeSort(rightArray);
            MergeTwoArrays(leftArray, rightArray, collection);
        }

        private static void MergeTwoArrays(T[] leftArray, T[] rightArray, IList<T> resultCollection)
        {
            int leftCounter = 0;
            int rightCounter = 0;

            for (int i = 0; i < resultCollection.Count; i++)
            {
                if (rightCounter >= rightArray.Length ||
                    (leftCounter < leftArray.Length) && leftArray[leftCounter].CompareTo(rightArray[rightCounter]) <= 0)
                {
                    resultCollection[i] = leftArray[leftCounter];
                    leftCounter++;
                }
                else if (leftCounter >= leftArray.Length ||
                         (rightCounter < rightArray.Length && rightArray[rightCounter].CompareTo(leftArray[leftCounter]) < 0))
                {
                    resultCollection[i] = rightArray[rightCounter];
                    rightCounter++;
                }
            }
        }
    }
}