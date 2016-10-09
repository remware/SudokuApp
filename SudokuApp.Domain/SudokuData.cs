using System.Collections.Generic;

namespace SudokuApp.Domain
{
    public class SudokuData
    {
        public IList<IList<int>> SudokuSquare { get; set; }

        private const int Maxsize = 9;

        public readonly List<int> EmptyRow = new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0};

        public SudokuData(IList<IList<int>> sudokuSquare)
        {
            SudokuSquare = sudokuSquare;
        }

        public void InitializeSquare()
        {
            for (var i = 0; i < Maxsize; i++)
            {
                SudokuSquare.Add(EmptyRow);
            }
        }
       

        private static void Expand(List<int> list, int index)
        {
            while (list.Count < index)
            {
                list.Add(default(int));
            }

        }
    }
}