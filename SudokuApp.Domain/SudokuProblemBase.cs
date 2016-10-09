using System.Collections.Generic;

namespace SudokuApp.Domain
{
    /// <summary>
    /// Sample Base generates sudoku puzzles as business domain
    /// </summary>
    public class SudokuProblemBase : SudokuData
    {               
        public SudokuProblemBase() : base(new List<IList<int>>())
        {
            InitializeSquare();
        }

        /// <summary>
        ///  Generate a sudoku problem ( easy )
        ///  might be later be randomized
        /// </summary>
        /// <param name="filledColumns"> Complexity: max amount of prefilled columns</param>
        /// <param name="maxComplexRows">Level: max number of rows having top complexity</param>
        /// <returns></returns>
        public IList<IList<int>> GetSudokuProblem(int filledColumns, int maxComplexRows)
        {
            // "Easy".Complexity = Columns = 6, LevelRows = 4
            SudokuSquare[0] = new List<int>() { 4, 3, 0,  8, 0, 6,  0, 5, 1 };
            SudokuSquare[1] = new List<int>() { 7, 2, 0,  1, 0, 3,  6, 0, 9 };
            SudokuSquare[2] = new List<int>() { 0, 6, 0,  0, 0, 0,  0, 2, 0 };

            SudokuSquare[3] = new List<int>() { 6, 9, 0,  0, 4, 0,  0, 2, 0 };
            SudokuSquare[4] = new List<int>() { 0, 0, 0,  7, 0, 2,  0, 0, 0 };
            SudokuSquare[5] = new List<int>() { 2, 7, 0,  0, 3, 0,  0, 8, 4 };

            SudokuSquare[6] = new List<int>() { 0, 4, 0,  0, 0, 0,  0, 9, 0 };
            SudokuSquare[7] = new List<int>() { 5, 0, 6,  9, 0, 4,  2, 0, 7 };
            SudokuSquare[8] = new List<int>() { 9, 2, 0,  3, 0, 5,  0, 1, 6 };
            return SudokuSquare;
        }
    }
}
