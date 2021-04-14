using Assignment.ViewModels;

namespace Assignment.State.Navigators
{
    public enum ViewType
    {
        Login,
        MeterToFeet,
        FeetToMeter
    }
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }

    }
}
