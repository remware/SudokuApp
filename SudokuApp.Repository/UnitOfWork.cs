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
    }
}
