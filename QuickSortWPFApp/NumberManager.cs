using System;
using System.Collections.ObjectModel;

namespace QuickSortWPFApp
{
    class NumberManager
    {
        private ObservableCollection<int> numbersToSort = new ObservableCollection<int>();
        private ObservableCollection<int> sortedResult = new ObservableCollection<int>();
        private int range;

        internal ObservableCollection<int> NumbersToSort { get => numbersToSort; set => numbersToSort = value; }
        internal ObservableCollection<int> SortedResult { get => sortedResult; set => sortedResult = value; }
        public int Range { get => range; set => range = value; }

        private static NumberManager instance = null;
        private NumberManager() { }
        public static NumberManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NumberManager();
                }
                return instance;
            }
        }


        public void GenerateNumbersInGivenRange(int range)
        {
            Random random = new Random();
            numbersToSort.Clear();

            for (int i = 1; i < range + 1; i++)
            {
                numbersToSort.Add(random.Next(range));
            }
        }

        public void SortNumbers(ObservableCollection<int> collectionToSort)
        {
            int[] arrayToSort = new int[collectionToSort.Count];
            collectionToSort.CopyTo(arrayToSort, 0);
            QuickSort(arrayToSort);
            foreach (int item in arrayToSort)
            {
                sortedResult.Add(item);
            }
        }

        #region QuickSort Algorithm


        public void QuickSort(int[] arrayToSort)
        {
            QuickSort(arrayToSort, 0, arrayToSort.Length - 1);
        }

        private void QuickSort(int[] arrayToSort, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int pivot = arrayToSort[(left + right) / 2];
            int index = Partition(arrayToSort, left, right, pivot);
            QuickSort(arrayToSort, left, index -1);
            QuickSort(arrayToSort, index, right);
        }

        private int Partition(int[] arrayToSort, int left, int right, int pivot)
        {
            while (left <= right)
            {
                while (arrayToSort[left] < pivot)
                {
                    left++;
                }

                while (arrayToSort[right] > pivot)
                {
                    right--;
                }

                if (left <= right)
                {
                    Swap(arrayToSort, left, right);
                    left++;
                    right--;
                }
            }
            return left;
        }

        private void Swap(int[] arrayToSort, int left, int right)
        {
            int temp = arrayToSort[left];
            arrayToSort[left] = arrayToSort[right];
            arrayToSort[right] = temp;
        }

        #endregion
    }
}
