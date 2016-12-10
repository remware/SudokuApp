namespace SudokuApp.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SudokuApp.Repository.SudokuContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SudokuContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.SudokuProblems.AddOrUpdate(p => p.Id,
                new SudokuDataAccess
                {
                    Id = 1,
                    Name = "Easy",
                    Author = "Rem",
                    ProblemState = "740900050020080000109007000850030012000158000610070085000700508000065030070004069",
                    Solved = false
                });

            context.SaveChanges();

        }
    }
}
