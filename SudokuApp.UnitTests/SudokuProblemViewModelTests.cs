using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SudokuApp.ViewModel;

namespace SudokuApp.UnitTests
{
    [TestClass]
    public class SudokuProblemViewModelTests : UnitTestBase
    {
        private MockRepository mockRepository;

        private IService anyService;

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
            var viewModel = GetViewModel();      
            // Act
            var first = viewModel.CurrentProblem;
            // Assert
            Assert.AreSame(ExpectedProblemList[0].Name, first.Name);


        }

        private SudokuProblemViewModel GetViewModel()
        {
            return new SudokuProblemViewModel(anyService);
        }

    }
}
