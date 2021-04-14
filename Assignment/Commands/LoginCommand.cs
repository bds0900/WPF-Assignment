using Assignment.State.Authenticators;
using Assignment.State.Navigators;
using Assignment.ViewModels;
using System;
using System.Windows.Input;

namespace Assignment.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _navigator;

        public LoginCommand(LoginViewModel loginViewModel, IAuthenticator authenticator, IRenavigator navigator)
        {
            _loginViewModel = loginViewModel;
            _authenticator = authenticator;
            _navigator = navigator;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// try to login and navigate to selected view
        /// </summary>
        /// <param name="parameter"> parameter value will be password</param>
        public async void Execute(object parameter)
        {
            //user name is bind to property in view but password can not bind to view since security issue
            //password will be passed through parameter
            bool success = await _authenticator.Login(_loginViewModel.Username, parameter.ToString());

            //if login is success, then navigate to current view
            //current view will be MeterToFeetView because renavigation is set to MeterToFeetViewModel
            if (success)
            {
                _navigator.Renavigate();
            }
        }
    }
}
