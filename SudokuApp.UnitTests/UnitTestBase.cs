using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SudokuApp.Model;
using SudokuApp.ViewModel;
using System.Collections.Generic;

namespace SudokuApp.UnitTests
{
    public class UnitTestBase
    {
        private Mock<IService> serviceMock = new Mock<IService>();
        public readonly List<SudokuProblem> ExpectedProblemList = new List<SudokuProblem>
        {
            new SudokuProblem
            {
                Name = "Easy",
                Complexity = 7,
                Level = 5
            }
        };

        [TestInitialize]
        private void TestSetup()
        {
            serviceMock.Setup(x => x.GetProblems())
                    .Returns(ExpectedProblemList);
            
        }
    }
        
}
