using Assignment.Commands;
using Assignment.State.Authenticators;
using Assignment.State.Navigators;
using Assignment.ViewModels.Factories;
using System.Windows.Input;

namespace Assignment.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; }
        public IAuthenticator Authenticator { get; set; }
        public ICommand UpdateCurrentViewModelCommand { get; }
        public MainViewModel(INavigator navigator, IViewModelFactory viewModelFactory, IAuthenticator authenticator)
        {
            Navigator = navigator;
            Authenticator = authenticator;
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, viewModelFactory);

            //mainViewModel start with LoginViewModel
            UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }
    }
}
