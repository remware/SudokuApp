using System.Data.Entity.Validation;
using System.Linq;

namespace SudokuApp.Repository
{
    public static class DbEntityValidationExceptionExtension
    {
        /// <summary>
        /// Get issues from db entity validation exception.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>Issues.</returns>
        public static string GetIssues(this DbEntityValidationException exception)
        {
            return exception.EntityValidationErrors.Aggregate("Validation exception\n",
                (current1, x) =>
                    x.ValidationErrors.Aggregate(current1,
                        (current, y) =>
                            current +
                            $"Property \"{y.PropertyName}\" validation failed due to: {y.ErrorMessage} \n"));
        }
    }
}
