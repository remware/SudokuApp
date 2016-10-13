using System.Threading.Tasks;
using SudokuApp.Model;

namespace SudokuApp.ViewModel
{
    public class SudokuSolutionViewModel : BaseNotifyPropertyChanged
    {
        private readonly IStorage _storage;

        public SudokuSolutionViewModel(IStorage storage)			
		{
            _storage = storage;
        }

        public async Task LoadProblemState()
        {
            var problem = await _storage.LoadAsync(ProblemState.Name);
            ProblemState.Challenge = problem;
        }


        protected async Task SaveProblemState()
        {
            
            await _storage.SaveAsync(ProblemState.Name, ProblemState.Challenge);
        }

        private SudokuProblem _problemState;
        public SudokuProblem ProblemState
        {
            get { return _problemState; }
            set
            {
                _problemState = value;
                RaisePropertyChanged("ProblemState");
            }
        }

    }
}
    