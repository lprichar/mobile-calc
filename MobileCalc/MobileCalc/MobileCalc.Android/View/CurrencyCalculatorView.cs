using Android.OS;
using Android.Support.V4.App;
using Android.Views;

namespace MobileCalc.Droid.View
{
    public class CurrencyCalculatorView : Fragment
    {
        public override Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var rootView = inflater.Inflate(Resource.Layout.currency_calculator_fragment, container, false);

            return rootView;
        }
    }
}