using System.Data.Entity.Validation;
using System.Threading.Tasks;

namespace SudokuApp.Repository
{
    public class GenericDataAccess : DataAccess, IDataAccess
    {
        public IRepository<TEntity> Get<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(Context);
        }

        public async Task CommitAsync()
        {
            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                throw new DbDataValidationFailedException(ex.GetIssues(), ex);
            }
        }
    }
}
