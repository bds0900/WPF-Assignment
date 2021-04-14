using Assignment.Models;
using Assignment.ViewModels;
using Domain.Services;

namespace Assignment.State.Navigators
{
    public class Navigator : ObservableObject, INavigator
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }
        private IConvertService _converter;
        public Navigator(IConvertService converter)
        {
            _converter = converter;
        }



    }
}
