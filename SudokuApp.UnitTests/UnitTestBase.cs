using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SudokuApp.Model;
using SudokuApp.ViewModel;
using System.Collections.Generic;

namespace SudokuApp.UnitTests
{
    public class UnitTestBase
    {
        private readonly Mock<IService> serviceMock = new Mock<IService>();
        private IService anyService;

        public readonly INavigator Navigator = new DefaultNavigator();

        public readonly List<SudokuProblem> ExpectedProblemList = new List<SudokuProblem>
        {
            new SudokuProblem
            {
                Name = "Easy",
                Complexity = 7,
                Level = 5
            }
        };
        public SudokuProblemViewModel GivenSudokuProblemViewModel()
        {
            return new SudokuProblemViewModel(anyService, Navigator);
        }

        [TestInitialize]
        private void TestSetup()
        {
            serviceMock.Setup(x => x.GetProblems())
                    .Returns(ExpectedProblemList);
            
        }
    }
        
}
