using System;
using System.ComponentModel;

namespace SudokuApp.Model
{
    public class SudokuProblem : INotifyPropertyChanged
    {
        private string name;


        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        // INotifyPropertyChanged required
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(property));
            }
        }

        // columns filled
        private int complexity;
        public int Complexity
        {
            get { return complexity; }
            set
            {
                complexity = value;
                RaisePropertyChanged("Complexity");
            }
        }

        // rows filled
        private int level;
        public int Level
        {
            get { return level; }
            set
            {
                level = value;
                RaisePropertyChanged("Level");
            }
        }

        public string DisplayText
        {
            get
            {
                return string.Format("{0} problem level: {1}, complexity: {2} ", Name, Level, Complexity);
            }
        }

        public override bool Equals(object obj)
        {
            return obj is SudokuProblem && ((SudokuProblem)obj).DisplayText.Equals(DisplayText);
        }

        public override int GetHashCode()
        {
            return DisplayText.GetHashCode();
        }

    }
}
