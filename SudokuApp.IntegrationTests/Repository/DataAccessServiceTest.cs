using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuApp.Repository;
using System.Data.Entity;

namespace SudokuApp.IntegrationTests
{
    [TestClass]
    public class DataAccessServiceTest
    {
        #region test data
        public class SudokuContextSeedInitializer : DropCreateDatabaseAlways<SudokuContext>
        {
            protected override void Seed(SudokuContext context)
            {
                context.SudokuProblems.Add(
                new SudokuDataAccess
                {
                    Id = 1,
                    Name = "Easy",
                    Author = "Test",
                    ProblemState = "740900050020080000109007000850030012000158000610070085000700508000065030070004069",
                    Solved = false
                });
                context.SaveChanges();
            }
        }
        #endregion

        [TestInitialize]
        public void Setup()

        {
            Database.SetInitializer(new SudokuContextSeedInitializer());
        }

        [TestMethod]
        public void WhenDbIsInitialized_SampleSudoku_isFound()
        {
            using (var repository = new SudokuRepository( new SudokuContext() ))
            {
                // arrange
                var easy = repository.GetSudokuProblems("Easy", 1);
                //act
                var result = easy.GetEnumerator();
                // assert
                Assert.IsNotNull(result);
               
            }
        }
    }

    
}
