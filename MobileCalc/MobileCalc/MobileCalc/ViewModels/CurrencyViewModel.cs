using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCalc.ViewModels
{
    public class CurrencyViewModel : ViewModelBase
    {
        public string Symbol1 { get; private set; }
        public string Display1 { get; private set; }

        public string Symbol2 { get; private set; }
        public string Display2 { get; private set; }

        public CurrencyViewModel()
        {
            Display1 = "0.00";
            Display2 = "0.00";
            Symbol1 = "$";
            Symbol2 = "€";
        }
    }
}
