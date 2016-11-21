using System;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;

namespace SudokuApp.Repository.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<SudokuContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        /// <summary>
        /// https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework60.html
        /// </summary>
        protected override void Seed(SudokuContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //    );
            //


            context.SudokuProblems.AddOrUpdate(p => p.Name, new SudokuDataAccess {Author = "Rem", Name = "Easy", Solved = false });

            context.SaveChanges();
            

        }
    }
}
