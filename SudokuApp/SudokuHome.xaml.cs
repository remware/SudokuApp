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
            // View Selection level
            var lbi =  ComplexityListBox.SelectedItem as ListBoxItem;
            var selected = lbi?.Content.ToString() ?? "Easy";
            
                var generateSudokuPage = new GenerationPage(selected);
                NavigationService.Navigate(generateSudokuPage);
            
        }
    }
}
