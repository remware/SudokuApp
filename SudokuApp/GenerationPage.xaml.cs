using SudokuApp.ViewModel;
using System.Windows;

namespace SudokuApp
{
    /// <summary>
    /// Interaction logic for GenerationPage.xaml
    /// </summary>
    public partial class GenerationPage
    {
        private string selectedLevel;

        public GenerationPage()
        {
            InitializeComponent();
        }

        // Custom constructor 
        public GenerationPage(string level) : this()
        {
            //  the level selected            
            selectedLevel = level;
            DataContext = new SudokuProblemViewModel(level);            
        }

        private void Go_Solve(object sender, RoutedEventArgs e)
        {            
            var gameBoardSudokuPage = new GameBoard(selectedLevel);
            NavigationService?.Navigate(gameBoardSudokuPage);
        }
    }
}
