using System;
using System.ComponentModel;
using System.Text;

namespace SudokuApp.ViewModel
{
    public class ProblemCell : IEditableObject, INotifyPropertyChanged
    {
        private CellUnit cell;

        public ProblemCell()
        {
            cell = new CellUnit();
        }

        public ProblemCell(CellUnit newCell)
        {
            cell = newCell;
        }

        public CellUnit ProblemCellUnit
        {
            get { return cell; }
            set
            {
                cell = value;
                RaisePropertyChange("ProblemCellUnit");
            }
        }

        public string Text
        {
            get
            {
                return cell.GetCellText();
            }
            set
            {
                cell.ChangeText(value);
                RaisePropertyChange("Text");
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChange(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public event ItemEndEditEventHandler ItemEndEdit;
        public void BeginEdit()
        {
            // No-op
        }

        public void CancelEdit()
        {
           // No-op
        }

        public void EndEdit()
        {
            ItemEndEdit?.Invoke(this);
        }
    }

    public delegate void ItemEndEditEventHandler(IEditableObject sender);
}