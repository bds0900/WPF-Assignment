using Assignment.Models;
using Domain.Models;
using Domain.Services.Authentication;
using System;
using System.Threading.Tasks;

namespace Assignment.State.Authenticators
{
    public class Authenticator : ObservableObject, IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;
        public Authenticator(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public User _currentUser;

        public User CurrentUser
        {
            get { return _currentUser; }
            private set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
                OnPropertyChanged(nameof(IsLoggedIn));
            }
        }

        public bool IsLoggedIn => CurrentUser != null;

        public async Task<bool> Login(string username, string password)
        {
            CurrentUser = await _authenticationService.Login(username, password);

            return await Task.Run(() => true);
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public async Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword)
        {
            throw new NotImplementedException();
            //return _authenticationService.Register(email,username,password,confirmPassword);
        }
    }
}
