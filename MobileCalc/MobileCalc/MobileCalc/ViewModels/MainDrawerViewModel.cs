using System.Collections.Generic;

namespace MobileCalc.ViewModels
{
    public class MainDrawerViewModel : ViewModelBase
    {
        public List<string> PageNames { get; set; } = new List<string>
        {
            "Standard",
            "Scientific",
            "Programmer",
            "Date Calculation"
        };
    }
}
