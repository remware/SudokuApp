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

        [TestMethod]
        public void GivenViewModel_WhenInitialized_ProblemsAreAvailable()
        {
            // Arrange
            var whenInitialized = new SudokuProblemViewModel(GivenDefaultServiceProvider());
            // Act
            var problemsAreListedIn = whenInitialized.Service.GetProblems();
            // Assert
            Assert.AreEqual(problemsAreListedIn.Capacity, ExpectedProblemList.Capacity);
        }

        [TestMethod]
        public void GivenViewModel_WhenNullService_ProblemsAreAvailable()
        {
            // Arrange
            var whenNullService = new SudokuProblemViewModel(null);
            // Act
            var problemsAreListedIn = whenNullService.Service.GetProblems();
            // Assert
            Assert.AreEqual(problemsAreListedIn.Capacity, ExpectedProblemList.Capacity);
        }

        private IService GivenDefaultServiceProvider()
        {
            return new DefaultServiceProvider();
        }
    }
}
