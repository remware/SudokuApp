using System.Collections.Generic;
using SudokuApp.Model;

namespace SudokuApp.ViewModel
{
    public interface IService
    {
        void DeleteProblem(SudokuProblem problem);

        List<SudokuProblem> GetProblems();       
    }
}
