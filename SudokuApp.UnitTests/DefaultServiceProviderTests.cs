using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuApp.ViewModel;

namespace SudokuApp.UnitTests
{
    [TestClass]
    public class DefaultServiceProviderTests : UnitTestBase
    {
        [TestMethod]
        public void GivenDefaultService_WhenServiceGetProblems_ProblemsAreListed()
        {
            // Arrange
            var whenService = GivenDefaultServiceProvider();
            // Act
            var problemsAreListedIn = whenService.GetProblems();
            // Assert
            Assert.AreEqual(problemsAreListedIn.Capacity, ExpectedProblemList.Capacity);
        }

        private IService GivenDefaultServiceProvider()
        {
            return new DefaultServiceProvider();
        }
    }
}
