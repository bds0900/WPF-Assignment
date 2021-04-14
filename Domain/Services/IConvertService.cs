using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IConvertService
    {
        Task<string> GetFeet(string meters);
        Task<string> GetMeter(string feets);
    }
}
