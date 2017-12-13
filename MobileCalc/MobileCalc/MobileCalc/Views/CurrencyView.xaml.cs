using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileCalc.Services;
using MobileCalc.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileCalc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrencyView : ContentPage
    {
        public CurrencyView()
        {
            InitializeComponent();
            var currencyViewModel = new CurrencyViewModel();
            BindingContext = currencyViewModel;
        }
    }
}