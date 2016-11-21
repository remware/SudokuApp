using System.Threading.Tasks;
using System.Data.Entity.Validation;

namespace SudokuApp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SudokuContext _context;

        public UnitOfWork(SudokuContext context)
        {
            _context = context;
            Sudokus = new SudokuRepository(context);             
        }

        public ISudokuRepository Sudokus { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                throw new DbDataValidationFailedException(ex.GetIssues(), ex);
            }
        }

    }
}
