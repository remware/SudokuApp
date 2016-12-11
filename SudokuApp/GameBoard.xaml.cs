using SudokuApp.ViewModel;
using System.Windows.Controls;

namespace SudokuApp
{
    /// <summary>
    /// Interaction logic for GameBoard.xaml
    /// </summary>
    public partial class GameBoard : Page
    {
        public GameBoard()
        {
            InitializeComponent();            
        }

        public GameBoard(string level) : this()
        {
            DataContext = new SudokuSolutionViewModel(level);
        }
    }
}
