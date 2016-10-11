using System.Collections.Generic;

namespace SudokuApp.Repository
{
    public interface ISudokuRepository : IRepository<SudokuDataAccess>
    {
        IEnumerable<SudokuDataAccess> GetEasySudokuProblems(int topCount);
        IEnumerable<SudokuDataAccess> GetMediumSudokProblems(int topCount);
        IEnumerable<SudokuDataAccess> GetDifficultSudokuProblems(int topCount);
    }
}