using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> Register(string email, string username, string password, string confirmPassword);
        Task<User> Login(string username, string password);
    }
}
