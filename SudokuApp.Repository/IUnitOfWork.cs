using System;
using System.Threading.Tasks;

namespace SudokuApp.Repository
{
    public interface IUnitOfWork : IDisposable
    {
         ISudokuRepository Sudokus { get; }

        /// <summary>
        /// Commit and save changes.
        /// </summary>
        int Complete();

        /// <summary>
        /// Commit and save changes async.
        /// </summary>
        Task CommitAsync();
    }
}