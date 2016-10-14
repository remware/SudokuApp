using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SudokuApp.Repository
{
    public class SudokuRepository : Repository<SudokuDataAccess>, ISudokuRepository
    {
        public SudokuRepository(DbContext context) : base(context)
        {
            // no-op
        }

        public SudokuContext SudokuContext => Context as SudokuContext;

        public IEnumerable<SudokuDataAccess> GetEasySudokuProblems(int topCount)
        {
            return SudokuContext.SudokuProblems.OrderByDescending(s => s.Name).Take(topCount);
        }

        public IEnumerable<SudokuDataAccess> GetMediumSudokProblems(int topCount)
        {
            return SudokuContext.SudokuProblems.Include(s => s.Name).OrderByDescending(s => s.Name).Take(topCount);
        }

        public IEnumerable<SudokuDataAccess> GetDifficultSudokuProblems(int topCount)
        {
            return SudokuContext.SudokuProblems.Include(s => s.Name).OrderByDescending(s => s.Name).Take(topCount);
        }
        
    }
}
