using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

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

        /// <summary>
        /// https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework60.html
        /// </summary>
        public static void Seeding()
        {
            var connectionString = "server=localhost;port=3305;database=parking;uid=root;";

            using (var connection = new SqlConnection(connectionString))
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
                        context.Database.Log = (string message) => { Console.WriteLine(message); };

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
