using Assignment.State.Navigators;
using System;

namespace Assignment.ViewModels.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly CreateViewModel<LoginViewModel> _loginViewModel;
        private readonly CreateViewModel<FeetToMeterViewModel> _feetToMeterViewModel;
        private readonly CreateViewModel<MeterToFeetViewModel> _meterToFeetViewModel;

        public ViewModelFactory(
            CreateViewModel<LoginViewModel> loginViewModel,
            CreateViewModel<FeetToMeterViewModel> feetToMeterViewModel,
            CreateViewModel<MeterToFeetViewModel> meterToFeetViewModel)
        {
            _loginViewModel = loginViewModel;
            _feetToMeterViewModel = feetToMeterViewModel;
            _meterToFeetViewModel = meterToFeetViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return _loginViewModel();
                case ViewType.MeterToFeet:
                    return _meterToFeetViewModel();
                case ViewType.FeetToMeter:
                    return _feetToMeterViewModel();
                default:
                    throw new ArgumentException("the view type doen't have viewmodel");
            }
        }
    }
}