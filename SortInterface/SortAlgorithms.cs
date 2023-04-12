namespace DataStructureImplementation.SortInterface
{
    internal interface ISortingAlgorithms
    {
        public void BubbleSort();
        public void InsertionSort();
        public void MergeSort(Person[] array, int left, int right);
        public void QuickSort(Person[] array, int left, int right);

    }
}
