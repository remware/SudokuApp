using System.ComponentModel;

namespace SudokuApp.ViewModel
{
    public abstract class BaseNotifyPropertyChanged : INotifyPropertyChanged
    {
        protected void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
