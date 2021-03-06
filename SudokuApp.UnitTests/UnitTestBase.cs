﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SudokuApp.Model;
using SudokuApp.ViewModel;
using System.Collections.Generic;

namespace SudokuApp.UnitTests
{
    public class UnitTestBase
    {
        private readonly Mock<IService> serviceMock = new Mock<IService>();
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
            return new SudokuProblemViewModel(serviceMock.Object, Navigator);
        }

        [TestInitialize]
        public void TestSetup()
        {
            serviceMock.Setup(x => x.GetProblems(It.IsAny<string>(), It.IsAny<int>()))
                    .Returns(ExpectedProblemList);
            
        }
    }
        
}
