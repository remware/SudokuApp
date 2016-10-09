using System.Collections.Generic;

namespace SudokuApp.Domain
{
    public class SudokuData
    {
        public IList<IList<int>> SudokuSquare { get; set; }

        public static int Maxsize => _maxsize;

        public readonly List<int> EmptyRow = new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0};

        public SudokuData(IList<IList<int>> sudokuSquare)
        {
            SudokuSquare = sudokuSquare;
        }

        public void InitializeSquare()
        {
            for (int i = 0; i < _maxsize; i++)
            {
                SudokuSquare.Add(EmptyRow);
            }
        }

        internal const int _maxsize = 9;

        private static void Expand(List<int> list, int index)
        {
            while (list.Count < index)
            {
                list.Add(default(int));
            }

        }
    }
}