using Assignment.Commands;
using Assignment.State.Authenticators;
using Assignment.State.Navigators;
using System.Windows.Input;

namespace Assignment.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(nameof(Username)); }
        }

        public ICommand LoginCommand { get; }
        public LoginViewModel(IAuthenticator authenticator, IRenavigator renavigator)
        {
            LoginCommand = new LoginCommand(this, authenticator, renavigator);
        }

    }
}
