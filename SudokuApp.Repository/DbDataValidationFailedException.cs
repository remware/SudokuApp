using System;

namespace SudokuApp.Repository
{
 
    public class DbDataValidationFailedException : Exception
    {
        public DbDataValidationFailedException(string issues, Exception exception)
            : base($"Data validation failed: {issues}", exception)
        {
            // No-op
        }

    }
}