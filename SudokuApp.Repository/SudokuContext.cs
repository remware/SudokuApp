using System.Data.Entity;

namespace SudokuApp.Repository
{
    public class SudokuContext : DbContext
    {
        public SudokuContext() : base("name=SudokuEntities")
        {
            // no-op
        }

        public virtual DbSet<SudokuDataAccess> SudokuProblems { get; set; }
    }
}
