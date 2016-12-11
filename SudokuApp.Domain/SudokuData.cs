using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuApp.Domain
{
    public class SudokuData
    {
        public IList<IList<int>> SudokuSquare { get; set; } = new List<IList<int>>();

        private const int Maxsize = 9;

        public readonly List<int> EmptyRow = new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0};

        public SudokuData(IList<IList<int>> sudokuSquare)
        {
            SudokuSquare = sudokuSquare;
        }

        public SudokuData(string packedData)
        {
           InitializeSquare();
            var pos = 0;
            var row = 0;
            if (packedData.Length != 81) return;

            foreach (var number in packedData)
            {
                SudokuSquare[row][pos] = (int) char.GetNumericValue(number);
                pos++;
                if (pos > Maxsize - 1)
                {
                    pos = 0;
                    row++;
                }
            }
        }

        public void InitializeSquare()
        {            
            for (var i = 0; i < Maxsize; i++)
            {
                SudokuSquare.Add(EmptyRow);
            }
        }

        public string State()
        {
            var stateSb = new StringBuilder();
            foreach (var row in SudokuSquare)
            {
                foreach (var column in row)
                {
                    stateSb.Append(row.ElementAt(column).ToString());
                }              
            }
            return stateSb.ToString();
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