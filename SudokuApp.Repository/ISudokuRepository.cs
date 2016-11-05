using System.Collections.Generic;

namespace SudokuApp.Repository
{
    public interface ISudokuRepository : IRepository<SudokuDataAccess>
    {
        IEnumerable<SudokuDataAccess> GetSudokuProblems(string complexity, int topCount);
    }
}