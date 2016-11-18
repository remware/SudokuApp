using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Data.Entity.Validation;

namespace SudokuApp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SudokuContext _context;

        public UnitOfWork(SudokuContext context)
        {
            _context = context;
            Sudokus = new SudokuRepository(context);             
        }

        public ISudokuRepository Sudokus { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                throw new DbDataValidationFailedException(ex.GetIssues(), ex);
            }
        }

        /// <summary>
        /// https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework60.html
        /// </summary>
        public void Seeder()
        {
            var connectionString = "server=localhost;port=3305;database=SudokuEntities;uid=root;password=123456";

            using (var connection = new MySqlConnection(connectionString))
            {
                // Create database if not exists
                using (var contextDb = new SudokuContext(connection, false))
                {
                    contextDb.Database.CreateIfNotExists();
                }

                connection.Open();
                var transaction = connection.BeginTransaction();

                try
                {
                    // DbConnection that is already opened
                    using (var context = new SudokuContext(connection, false))
                    {

                        // Interception/SQL logging
                        context.Database.Log = (message) => { Console.WriteLine(message); };

                        // Passing an existing transaction to the context
                        context.Database.UseTransaction(transaction);

                        // DbSet.AddRange
                        var easyProbs = new List<SudokuDataAccess>
                        {
                            new SudokuDataAccess {Author = "Rem", Name = "Easy", Solved = false}
                        };

                        context.SudokuProblems.AddRange(easyProbs);

                        context.SaveChanges();
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
