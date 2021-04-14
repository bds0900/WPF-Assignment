using Assignment.Models;

namespace Assignment.State
{
    public class SharedState : ObservableObject
    {
        public string Feet { get; set; }
        public string Meter { get; set; }
    }
}
