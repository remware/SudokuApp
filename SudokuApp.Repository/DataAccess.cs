using System;

namespace SudokuApp.Repository
{
    public abstract class DataAccess : IDisposable
    {
        protected readonly SudokuContext Context = new SudokuContext();

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DataAccess()
        {
            Dispose(false);
        }
    }
}
