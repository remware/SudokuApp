using System.Windows.Controls;

namespace SudokuApp
{
    /// <summary>
    /// Interaction logic for GenerationPage.xaml
    /// </summary>
    public partial class GenerationPage : Page
    {
        public GenerationPage()
        {
            InitializeComponent();
        }

        // Custom constructor to pass generator data
        public GenerationPage(object data) : this()
        {
            // Bind to expense report data.
            this.DataContext = data;
        }
    }
}
