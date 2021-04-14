using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ConvertService : IConvertService
    {
        /// <summary>
        /// Convert meters to feet, prarameter type is string not double
        /// </summary>
        /// <param name="meters"></param>
        /// <returns>converted value</returns>
        public Task<string> GetFeet(string meters)
        {
            double _meters;
            if (String.IsNullOrEmpty(meters)) return Task.Run(() => "");
            try
            {
                _meters = Convert.ToDouble(meters);
            }
            catch (Exception ex)
            {
                return Task.Run(() => "");
            }
            NumberFormatInfo setPrecision = new NumberFormatInfo { NumberDecimalDigits = 4 };
            setPrecision.NumberDecimalDigits = 4;
            return Task.Run(() => (_meters * 3.37).ToString("N", setPrecision));
        }

        /// <summary>
        /// Convert feet to meters, prarameter type is string not double
        /// </summary>
        /// <param name="feets"></param>
        /// <returns>converted value</returns>
        public Task<string> GetMeter(string feets)
        {
            double _feets;
            if (String.IsNullOrEmpty(feets)) return Task.Run(() => "");

            try
            {
                _feets = Convert.ToDouble(feets);
            }
            catch (Exception ex)
            {
                return Task.Run(() => "");
            }

            NumberFormatInfo setPrecision = new NumberFormatInfo { NumberDecimalDigits = 4 };
            return Task.Run(() => (_feets / 3.37).ToString("N", setPrecision));
        }
    }
}
