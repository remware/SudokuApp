using System.Collections.Generic;
using SudokuApp.Model;

namespace SudokuApp.ViewModel
{
    /// <summary>
    /// Interface to Sudoku Problems in repository
    /// Inteface segregated to minimum 
    /// </summary>
    public interface IService
    {
        void DeleteProblem(SudokuProblem problem);

        List<SudokuProblem> GetProblems(string level, int amount);       
    }
}
