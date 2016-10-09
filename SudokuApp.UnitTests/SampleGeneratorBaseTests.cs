using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SudokuApp.Domain;

namespace SudokuApp.UnitTests
{
    [TestClass]
    public class SampleGeneratorBaseTests
    {
        private MockRepository mockRepository;
        private readonly int easyColumns = 6;
        private readonly int easyRows = 4;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void GivenGenerator_WhenInitialized_SudokuProblemIsAvailable()
        {
            // arrange
            SampleGeneratorBase sampleGeneratorBase = CreateSampleGeneratorBase();
            //  act
            var sample = sampleGeneratorBase.GetSudokuProblem(easyColumns, easyRows);
            // assert
            Assert.AreNotEqual(sample, sampleGeneratorBase.EmptyRow);
        }

        private SampleGeneratorBase CreateSampleGeneratorBase()
        {
            return new SampleGeneratorBase();
        }
    }
}
