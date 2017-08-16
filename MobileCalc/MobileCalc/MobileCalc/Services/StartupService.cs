using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileCalc.ViewModels;

namespace MobileCalc.Services
{
    public class StartupService
    {
        public static void Startup()
        {
            ServiceContainer.Register(() => new CalculatorViewModel());
        }
    }
}
