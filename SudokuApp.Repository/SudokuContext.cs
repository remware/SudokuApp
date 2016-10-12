using System;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using MySql.Data.Entity;

namespace SudokuApp.Repository
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class SudokuContext : DbContext
    {
        public SudokuContext() : base("name=SudokuEntities")
        {
            // no-op
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

            return base.SaveChanges();
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
    }
}
