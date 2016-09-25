using System.Windows;
using System.Windows.Controls;

namespace SudokuApp
{
    /// <summary>
    /// Interaction logic for SudokuHome.xaml
    /// </summary>
    public partial class SudokuHome : Page
    {
        public SudokuHome()
        {
            InitializeComponent();
        }

        private void Go_Generate(object sender, RoutedEventArgs e)
        {
            // View Expense Report
            GenerationPage generateSudokuPage = new GenerationPage(this.complexityListBox.SelectedItem);
            this.NavigationService.Navigate(generateSudokuPage);

        }
    }
}
