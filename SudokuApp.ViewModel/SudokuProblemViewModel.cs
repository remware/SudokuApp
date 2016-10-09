using SudokuApp.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SudokuApp.ViewModel
{
    public class SudokuProblemViewModel : BaseNotifyPropertyChanged
    {      
        public SudokuProblemViewModel(IService service, INavigator navigator)
        {
 
            Problems = new ObservableCollection<SudokuProblem>();
            
            Service = service ?? new DefaultServiceProvider();

            Navigator = navigator;

            PopulateProblems(Service.GetProblems());

            Delete = new DeleteCommand(
                Service,
                () => CanDelete,
                problem =>
                {
                    CurrentProblem = null;
                    PopulateProblems(Service.GetProblems());
                });

            CurrentProblem = Problems.FirstOrDefault();
        }

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
        public bool CanDelete
        {
            get { return CurrentProblem != null; }
        }

        private SudokuProblem currentProblem;
        public SudokuProblem CurrentProblem
        {
            get { return currentProblem; }
            set
            {
                currentProblem = value;
                RaisePropertyChanged("CurrentProblem");
                RaisePropertyChanged("CanDelete");
                Delete.RaiseCanExecuteChanged();
            }
        }
    }
}
