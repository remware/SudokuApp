using System;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using MySql.Data.Entity;
using System.Data.Entity.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace SudokuApp.Repository
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class SudokuContext : DbContext
    {
        /// <summary>
        /// MySQL Context needs database name in lower letters
        /// </summary>
        public SudokuContext() : base("name=sudokuentities")
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

            modelBuilder.Entity<SudokuDataAccess>()
                .ToTable("SudokuPoblems")
                .MapToStoredProcedures()
                .HasKey(entity => entity.Id)
                .Property(entity => entity.Id).HasColumnName("id_problem").IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                

           

            base.OnModelCreating(modelBuilder);
           
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
            catch (System.Data.Entity.Core.UpdateException e)
            {
                Console.WriteLine(e);
                throw;
            }

            catch (System.Data.Entity.Infrastructure.DbUpdateException ex) //DbContext
            {
                Console.WriteLine(" error occurred: " + ex.Message + " inner " + ex.InnerException);
                throw;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex) 
            {
                Console.WriteLine("Error " + ex.Number + " has occurred: " + ex.Message + " inner " + ex.InnerException);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
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
                entry.Property("UpdatedDate").CurrentValue = DateTime.Now;
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
