using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace SudokuApp.UnitTests
{
    [TestClass]
    public class SudokuProblemViewModelTests : UnitTestBase
    {
        private MockRepository mockRepository;        

        [TestInitialize]
        public void TestInitialize()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void GivenSudokuProblemViewModel_WhenSetEasyLevel_AnEasyProblemIsLoaded()
        {
            // Arrange            
            var viewModel = GivenSudokuProblemViewModel();      
            // Act
            var easyLevel = viewModel.CurrentProblem;
            // Assert
            Assert.AreSame(ExpectedProblemList[0].Name, easyLevel.Name);
        }

        [TestMethod]
        public void GivenSudokuProblemView_NavigateToSolution_IsOK()
        {
            // Arrange
            var viewModel = this.GivenSudokuProblemViewModel();            
            //Act
            viewModel.ViewSudokuProblem(viewModel.CurrentProblem);
            //Assert
            Assert.IsNotNull(viewModel.CurrentProblem);
        }

    }
}
