using System;

namespace SudokuApp.Repository
{
    public class ProblemsInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<SudokuContext>
    {
        protected override void Seed(SudokuContext context )
        {
            using (var db = new SudokuContext())
            {
                db.SudokuProblems.Add(new SudokuDataAccess { Name = "Easy" });
                db.SaveChanges();

                foreach (var problem in db.SudokuProblems)
                {
                    Console.WriteLine(problem.Name);
                }
            }
        }

    }
}
