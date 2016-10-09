using System.Collections.Generic;
using System.Threading.Tasks;
using SudokuApp.Model;

namespace SudokuApp.ViewModel
{
    public class SudokuSolutionViewModel : BaseNotifyPropertyChanged
    {
        private readonly IStorage Storage;

        public SudokuSolutionViewModel(IStorage storage)			
		{
            Storage = storage;
        }

        public async Task LoadProblemState()
        {
            var problem = await Storage.LoadAsync<SudokuProblem>(ProblemState.Name);
            ProblemState.Challenge = problem.Challenge;
        }


        protected async Task SaveProblemState()
        {
            
            await Storage.SaveAsync(ProblemState.Name, ProblemState.Challenge);
        }

        private SudokuProblem problemState;
        public SudokuProblem ProblemState
        {
            get { return problemState; }
            set
            {
                problemState = value;
                RaisePropertyChanged("ProblemState");
            }
        }

    }
}
    