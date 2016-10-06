using SudokuApp.Model;
using System.Collections.Generic;

namespace SudokuApp.ViewModel
{
    public class DefaultServiceProvider : IService
    {
        public void DeleteProblem(SudokuProblem problem)
        {
            //
        }

        public List<SudokuProblem> GetProblems()
        {
            var available = new List<SudokuProblem>();
            return available;
        }
    }
}
