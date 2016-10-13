namespace SudokuApp.Repository
{
    public class ProblemsInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<SudokuContext>
    {
        protected override void Seed(SudokuContext context )
        {
             new UnitOfWork(context).Seeder();            
        }
    }
}
