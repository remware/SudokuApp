using SudokuApp.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SudokuApp.ViewModel
{
    public class SudokuProblemViewModel : BaseNotifyPropertyChanged
    {      

        public SudokuProblemViewModel(IService service)
        {
 
            Problems = new ObservableCollection<SudokuProblem>();
            
            Service = (service == null) ? new DefaultServiceProvider() : service;

            PopulateProblems(Service.GetProblems());

            Delete = new DeleteCommand(
                Service,
                () => CanDelete,
                problem =>
                {
                    CurrentProblem = null;
                    PopulateProblems(Service.GetProblems());
                });
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
