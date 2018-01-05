using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
