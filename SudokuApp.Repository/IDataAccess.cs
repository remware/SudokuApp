using System;

namespace SudokuApp.Repository
{
    public interface IDataAccess : IDisposable
    {
        // data access object can access data and is always disposable
    }
}
