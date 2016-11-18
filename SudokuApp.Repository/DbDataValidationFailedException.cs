using System;
using System.Data.Entity.Validation;
using System.Runtime.Serialization;

namespace SudokuApp.Repository
{
    [Serializable]
    public class DbDataValidationFailedException : Exception
    {
        public DbDataValidationFailedException(string issues, Exception exception)
            : base($"Data validation failed: {issues}", exception)
        {
            // No-op
        }

    }
}