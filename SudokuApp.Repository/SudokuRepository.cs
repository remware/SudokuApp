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

        public IEnumerable<SudokuDataAccess> GetSudokuProblems(string complexity, int topCount)
        {
            var topProblems = SudokuContext.SudokuProblems
                      .Where(p => p.Name.Contains(complexity)).Take(topCount);

            return topProblems;            
        }



    }
}
