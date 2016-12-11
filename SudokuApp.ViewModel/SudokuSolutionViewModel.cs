using System.Threading.Tasks;
using SudokuApp.Model;
using System.Collections.ObjectModel;
using SudokuApp.Domain;
using System.Linq;
using System.Data;
using System.Collections.Generic;

namespace SudokuApp.ViewModel
{
    public class SudokuSolutionViewModel : BaseNotifyPropertyChanged
    {
        private readonly IStorage _storage;

        public SudokuSolutionViewModel(IStorage storage)			
		{
            _storage = storage;
        }

        public SudokuSolutionViewModel(string level)
        {
            if (_storage == null) _storage = new SudokuStore();

            // load the dataset
            var dataset = _storage.LoadAsync(level);

            // populate problem cells
            UpdateProblemCells(dataset.Result);

            // Convert problem  cells to DataTable.
            CellsTable = ConvertListToDataTable();
        }

        public DataTable CellsTable { get; set; }

        private DataTable ConvertListToDataTable()
        {
            // New table.
            DataTable table = new DataTable();
            
            // Add columns.
            for (int i = 0; i < 3; i++)
            {
                table.Columns.Add();
            }
            
            // Create list.
            var rowCell = new List<string>();
            var row = 0;
            foreach (var cell in ProblemCells)
            {
                rowCell.Add(cell.Text);
                ++row;
                if (row % 3 == 0)
                {
                    rowCell.Clear();
                    row = 0;
                    // add rows
                    table.Rows.Add(rowCell);
                }

                                                
            }

            return table;
        }

        public ObservableCollection<ProblemCell> ProblemCells = new ObservableCollection<ProblemCell>();

        private void UpdateProblemCells(SudokuData problem)
        {
            foreach ( var unit in Enumerable.Range(1, 9))
            {
                ProblemCells.Add(new ProblemCell());
            }

            var row = 0;
            foreach(var series in problem.SudokuSquare)
            {
                var column = 0;
                foreach (var value in series)
                {
                    var cellIndex = (column % 3) + row % 3;
                    ProblemCells[cellIndex].ProblemCellUnit.SetRowCol(row % 3, column % 3, value);
                    ++column;
                }
                ++row;
            }
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
    