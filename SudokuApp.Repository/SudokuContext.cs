using System;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using MySql.Data.Entity;
using System.Data.Entity.Validation;

namespace SudokuApp.Repository
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class SudokuContext : DbContext
    {
        public SudokuContext() : base("name=SudokuEntities")
        {
            // default construction
        }

        public SudokuContext(string databaseName) : base(databaseName)
        {
            // constructor to use a different database name
        }

        // Constructor to use on a DbConnection that is already opened
        public SudokuContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
            // no-op
        }

        public virtual DbSet<SudokuDataAccess> SudokuProblems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SudokuDataAccess>().HasKey(m => m.Id);

            // shadow properties
            modelBuilder.Entity<SudokuDataAccess>().Property<DateTime>(access => access.UpdatedDate);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SudokuDataAccess>().MapToStoredProcedures();
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            UpdateUpdatedProperty<SudokuDataAccess>();
            int result;

            try
            {
                result = base.SaveChanges(); 
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            return result;
        }

        private void UpdateUpdatedProperty<T>() where T : class
        {
            var modifiedSourceInfo =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in modifiedSourceInfo)
            {
                entry.Property("UpdatedDate").CurrentValue = DateTime.UtcNow;
            }
        }

        private static void BackupDatabaseCopy()
        {
            using (var context =
            new SudokuContext("SudokuEntitiesBackup"))
            {
                context.SudokuProblems.Add(new SudokuDataAccess
                {
                    Name = "Difficult",
                    ProblemState = "000000704003207000080090530000074000049506280000820000012050090090702300506000000",
                    Author = "Rem"
                });
                context.SaveChanges();
            }
        }
        
    }
}
