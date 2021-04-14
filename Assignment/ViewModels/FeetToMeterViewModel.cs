using Assignment.State;
using Domain.Services;

namespace Assignment.ViewModels
{
    public class FeetToMeterViewModel : ViewModelBase
    {
        private readonly IConvertService _converter;
        private SharedState _sharedState;
        public FeetToMeterViewModel(IConvertService converter, SharedState sharedState)
        {
            _converter = converter;
            _feet = sharedState.Feet;
            _meter = sharedState.Meter;
            _sharedState = sharedState;
        }
        private string _feet;
        public string Feet
        {
            get
            {
                return _feet;
            }
            set
            {
                _feet = value;
                _meter = _converter.GetMeter(_feet).Result;
                _sharedState.Feet = _feet;
                _sharedState.Meter = _meter;
                OnPropertyChanged(nameof(Feet));
                OnPropertyChanged(nameof(Meter));
            }
        }
        private string _meter;
        public string Meter
        {
            get => _meter;
            set => _meter = value;
        }
    }
}
