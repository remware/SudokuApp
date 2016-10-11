using System;

namespace SudokuApp.Repository
{
    public interface IUnitOfWork : IDisposable
    {
         ISudokuRepository Sudokus { get; }
        int Complete();
    }
}