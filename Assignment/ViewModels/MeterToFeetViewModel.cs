using Assignment.State;
using Domain.Services;

namespace Assignment.ViewModels
{
    public class MeterToFeetViewModel : ViewModelBase
    {
        private readonly IConvertService _converter;
        private SharedState _sharedState;
        public MeterToFeetViewModel(IConvertService converter, SharedState sharedState)
        {
            _converter = converter;
            _feet = sharedState.Feet;
            _meter = sharedState.Meter;
            _sharedState = sharedState;
        }
        private string _feet;
        public string Feet
        {
            get => _feet;
            set => _feet = value;
        }
        private string _meter;
        public string Meter
        {
            get
            {
                return _meter;
            }
            set
            {
                _meter = value;
                _feet = _converter.GetFeet(_meter).Result;
                _sharedState.Feet = _feet;
                _sharedState.Meter = _meter;
                OnPropertyChanged(nameof(Feet));
                OnPropertyChanged(nameof(Meter));
            }
        }
    }
}
