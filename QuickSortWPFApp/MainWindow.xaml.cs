using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuickSortWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        NumberManager numberManager = NumberManager.Instance;
        MainWindow mw = (MainWindow)Application.Current.MainWindow;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            numberManager.GenerateNumbersInGivenRange(numberManager.Range);

        }

        private void NumbersToGenerateSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            numberManager.Range = (int)NumbersToGenerateSlider.Value;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            numberManager.Range = (int)NumbersToGenerateSlider.Value;
            NumbersToSortListView.ItemsSource = numberManager.NumbersToSort;
            SortedResultListView.ItemsSource = numberManager.SortedResult;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            numberManager.SortNumbers(numberManager.NumbersToSort);
        }
    }
}
