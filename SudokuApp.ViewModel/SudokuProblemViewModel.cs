using SudokuApp.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SudokuApp.ViewModel
{
    public class SudokuProblemViewModel : BaseNotifyPropertyChanged
    {
        private const int ProblemsPerPage = 3;

        public SudokuProblemViewModel(string level)
        {
            Service = new DefaultServiceProvider();
            Navigator = new DefaultNavigator();
            SelectedLevel = level;
            InitializeVm();
        }

        public SudokuProblemViewModel(IService service, INavigator navigator)
        {                         
            Service = service ?? new DefaultServiceProvider();
            Navigator = navigator;
            SelectedLevel = "Easy";
            InitializeVm();
        }

        public void InitializeVm()
        {
            Problems = new ObservableCollection<SudokuProblem>();

            PopulateProblems(Service.GetProblems(SelectedLevel, ProblemsPerPage));

            Delete = new DeleteCommand(
                Service,
                () => CanDelete,
                problem =>
                {
                    CurrentProblem = null;
                    PopulateProblems(Service.GetProblems(SelectedLevel, ProblemsPerPage));
                });

            CurrentProblem = Problems.FirstOrDefault();
        }

        public string SelectedLevel { get; set; }

        public void ViewSudokuProblem(SudokuProblem problem)
        {
            Navigator.NavigateToViewModel<SudokuSolutionViewModel>(problem);
        }
        private void PopulateProblems(IEnumerable<SudokuProblem> problems)
        {
            Problems.Clear();
            foreach (var problem in problems)
            {
                Problems.Add(problem);
            }
        }


        public DeleteCommand Delete { get; private set; }
        public ObservableCollection<SudokuProblem> Problems { get; private set; }
        public IService Service { get; private set; }

        public INavigator Navigator { get; private set; }
        public bool CanDelete => CurrentProblem != null;

        private SudokuProblem _currentProblem;
        public SudokuProblem CurrentProblem
        {
            get { return _currentProblem; }
            set
            {
                _currentProblem = value;
                RaisePropertyChanged("CurrentProblem");
                RaisePropertyChanged("CanDelete");
                Delete.RaiseCanExecuteChanged();
            }
        }
    }
}
