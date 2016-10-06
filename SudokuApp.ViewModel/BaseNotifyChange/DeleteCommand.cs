using SudokuApp.Model;
using System;
using System.Windows;
using System.Windows.Input;

namespace SudokuApp.ViewModel
{
    public class DeleteCommand : ICommand
    {
        private readonly IService _service;
        private readonly Func<bool> _canExecute;
        private readonly Action<SudokuProblem> _deleted;

        public DeleteCommand(IService service, Func<bool> canExecute,
                                  Action<SudokuProblem> deleted)
        {
            _service = service;
            _canExecute = canExecute;
            _deleted = deleted;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute();
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                var problem = parameter as SudokuProblem;
                if (problem != null)
                {
                    var result = MessageBox.Show(
                      "Are you sure you wish to delete the problem?",
                      "Confirm Delete", MessageBoxButton.OKCancel);

                    if (result.Equals(MessageBoxResult.OK))
                    {
                        _service.DeleteProblem(problem);
                        if (_deleted != null)
                        {
                            _deleted(problem);
                        }
                    }
                }
            }
        }

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
