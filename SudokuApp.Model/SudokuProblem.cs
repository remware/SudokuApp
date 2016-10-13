using SudokuApp.Domain;
using System;
using System.ComponentModel;

namespace SudokuApp.Model
{
    public class SudokuProblem : INotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        // INotifyPropertyChanged required
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        // columns filled
        private int _complexity;
        public int Complexity
        {
            get { return _complexity; }
            set
            {
                _complexity = value;
                RaisePropertyChanged("Complexity");
            }
        }

        // rows filled
        private int _level;
        public int Level
        {
            get { return _level; }
            set
            {
                _level = value;
                RaisePropertyChanged("Level");
            }
        }

        public string DisplayText => $"{Name} problem level: {Level}, complexity: {Complexity} ";

        public SudokuData Challenge;

        public override bool Equals(object obj)
        {
            var problem = obj as SudokuProblem;
            return problem != null && problem.DisplayText.Equals(DisplayText);
        }

        public override int GetHashCode()
        {
            return DisplayText.GetHashCode();
        }

    }
}
