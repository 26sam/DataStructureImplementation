using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureImplementation.DSSortingAlgorithms
{
    internal class ArraySort<T> where T : IComparable<T>
    {
        protected void BubbleSort(T[] tempArray)
        {
            int arraySize = tempArray.Length;

            for (int i = 0; i < arraySize - 1; i++)
            {
                for (int j = 0; j < arraySize - i - 1; j++)
                {
                    if (tempArray[j].CompareTo(tempArray[j + 1]) <= 0)
                    {
                        T temp = tempArray[j];
                        tempArray[j] = tempArray[j + 1];
                        tempArray[j + 1] = temp;
                    }
                }
            }
        }
        protected void InsertionSort(T[] tempArray)
        {
            int arraySize = tempArray.Length;
            for (int i = 1; i < arraySize; i++)
            {
                T key = tempArray[i];
                int j = i - 1;
                while (j >= 0 && key.CompareTo(tempArray[j]) > 0)
                {
                    tempArray[j + 1] = tempArray[j];
                    j--;
                }
                tempArray[j + 1] = key;
            }
        }
        private void Merge(T[] tempArray, int left, int mid, int right)
        {
            int leftLength = mid - left + 1;
            int rightLength = right - mid;
            var leftTempArray = new T[leftLength];
            var rightTempArray = new T[rightLength];
            int i, j;

            for (i = 0; i < leftLength; i++)
                leftTempArray[i] = tempArray[i + left];
            for (j = 0; j < rightLength; j++)
                rightTempArray[j] = tempArray[mid + 1 + j];
            i = 0; j = 0;
            int k = left;

            while (i < leftLength && j < rightLength)
            {
                if (leftTempArray[i].CompareTo(rightTempArray[j]) <= 0)
                    tempArray[k++] = leftTempArray[i++];
                else
                    tempArray[k++] = rightTempArray[j++];
            }

            while (i < leftLength)
                tempArray[k++] = leftTempArray[i++];
            while (j < rightLength)
                tempArray[k++] = rightTempArray[j++];

            return;
        }
        protected void MergeSort(T[] tempArray, int left, int right)
        {
            if (right <= left)
                return;

            int mid = left + (right - left) / 2;
            MergeSort(tempArray, left, mid);
            MergeSort(tempArray, mid + 1, right);

            Merge(tempArray, left, mid, right);
        }
        private int Pivot(T[] tempArray, int leftIndex, int rightIndex)
        {
            T pivot = tempArray[rightIndex];
            int i = (leftIndex - 1);
            T temp;
            for (int j = leftIndex; j <= rightIndex - 1; j++)
            {
                if (tempArray[j].CompareTo(pivot) <= 0)
                {
                    i++;
                    temp = tempArray[i];
                    tempArray[i] = tempArray[j];
                    tempArray[j] = temp;
                }
            }
            temp = tempArray[i + 1];
            tempArray[i + 1] = tempArray[rightIndex];
            tempArray[rightIndex] = temp;

            return (i + 1);
        }
        protected void QuickSort(T[] tempArray, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int pivot = Pivot(tempArray, leftIndex, rightIndex);
                QuickSort(tempArray, leftIndex, pivot - 1);
                QuickSort(tempArray, pivot + 1, rightIndex);
            }
        }
    }
}
