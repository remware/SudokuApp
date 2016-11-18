using SudokuApp.ViewModel;
using System.Windows.Controls;

namespace SudokuApp
{
    /// <summary>
    /// Interaction logic for GenerationPage.xaml
    /// </summary>
    public partial class GenerationPage
    {
        public GenerationPage()
        {
            InitializeComponent();
        }

        // Custom onstructor 
        public GenerationPage(string level) : this()
        {
            //  the level selected            
            DataContext = new SudokuProblemViewModel(level);            
        }
    }
}
