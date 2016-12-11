using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuApp.ViewModel
{
    public class CellUnit
    {
        private readonly IList<IList<int>> cellUnits  = new List<IList<int>>();        

        public CellUnit()
        {
            foreach (var unit in Enumerable.Range(1, 3))
            {
                cellUnits.Add(new List<int> {0,0,0 });
            }
        }
        public void SetRowCol(int row, int column, int value)
        {
            cellUnits[row][column] = value;
        }

        public IList<IList<int>> GetCellSquare()
        {
            return cellUnits;
        }

        public string GetCellText()
        {
            StringBuilder sb = new StringBuilder();  
            foreach (var row in cellUnits)
            {
                foreach (var value in row)
                {
                    sb.Append(value + " ");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

        public  void ChangeText(string input)
        {
            // not yet
        }
    }
}