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
        private static void Seed()
        {
            // pass SudokuContext context parameter in the future
            Database.SetInitializer( new DropCreateDatabaseAlways<SudokuContext>());            ;
        }
        #endregion

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
