using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SudokuApp.ViewModel;
using SudokuApp.Repository;

namespace SudokuApp.UnitTests
{   
    [TestClass]
    public class DefaultServiceProviderTests : UnitTestBase
    {
        private const string ChallengeLevel = "Difficult";
        private const int NumberOfProblems = 1;
        private Mock<ISudokuRepository> _mockISudokuRepository;

        [TestInitialize]
        public void Setup()
        {
            _mockISudokuRepository = new Mock<ISudokuRepository>();
            var expectedProblem = new List<SudokuDataAccess>
            {
                new SudokuDataAccess
                {
                    Name = ChallengeLevel,
                    ProblemState = "000000704003207000080090530000074000049506280000820000012050090090702300506000000",
                    Id = 1
                }
            };
            _mockISudokuRepository.Setup(x => x.GetSudokuProblems(ChallengeLevel, It.IsAny<int>())).Returns(expectedProblem);
        }

        [TestMethod]
        public void GivenDefaultService_WhenServiceGetProblems_ProblemsAreListed()
        {
            // Arrange
            var whenService = GivenDefaultServiceProvider();
            // Act
            var problemsAreListedIn = whenService.GetProblems(ChallengeLevel, NumberOfProblems);
            // Assert
            Assert.AreEqual(problemsAreListedIn.Capacity, ExpectedProblemList.Capacity);
        }

        [TestMethod]
        public void GivenViewModel_WhenInitialized_ProblemsAreAvailable()
        {
            // Arrange
            var whenInitialized = new SudokuProblemViewModel(GivenDefaultServiceProvider(), Navigator);
            // Act
            var problemsAreListedIn = whenInitialized.Service.GetProblems(ChallengeLevel, NumberOfProblems);
            // Assert
            Assert.AreEqual(problemsAreListedIn.Capacity, ExpectedProblemList.Capacity);
        }

        [TestMethod]
        public void GivenViewModel_WhenNullService_ProblemsAreAvailable()
        {
            // Arrange
            var whenNullService = GivenSudokuProblemViewModel();
            // Act
            var problemsAreListedIn = whenNullService.Service.GetProblems(ChallengeLevel, NumberOfProblems);
            // Assert
            Assert.AreEqual(problemsAreListedIn.Capacity, ExpectedProblemList.Capacity);
        }

        private IService GivenDefaultServiceProvider()
        {
            
            return new DefaultServiceProvider(_mockISudokuRepository.Object);
        }
    }
}
