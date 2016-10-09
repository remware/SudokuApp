using System;

namespace SudokuApp.ViewModel
{
    public class DefaultNavigator : INavigator
    {
        public bool CanGoBack { get; set; }
        public Action GoBackDelegate { get; set; }

        public void GoBack()
        {
            GoBackDelegate?.Invoke();
        }

        public Action<Type, object> NavigateToViewModelDelegate { get; set; }
        public void NavigateToViewModel<TViewModel>(object parameter = null)
        {
            NavigateToViewModelDelegate?.Invoke(typeof(TViewModel), parameter);
        }
    }
}
