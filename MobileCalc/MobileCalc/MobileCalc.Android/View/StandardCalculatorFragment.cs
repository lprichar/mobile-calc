using System;
using System.ComponentModel;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using MobileCalc.Services;
using MobileCalc.ViewModels;

namespace MobileCalc.Droid.View
{
	public class StandardCalculatorFragment : Fragment
	{
		int count = 1;
	    private Button _equals;
	    private CalculatorViewModel _viewModel;
	    private Button _btn1;
	    private TextView _display;
	    private Button _btn0;
	    private Button _btn2;
	    private Button _btn3;
	    private Button _btn4;
	    private Button _btn5;
	    private Button _btn6;
	    private Button _btn7;
	    private Button _btn8;
	    private Button _btn9;
	    private Button _plus;

	    public override Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
	    {
            // todo: implement a splash screen and call Startup() from there
	        StartupService.Startup();

            _viewModel = ServiceContainer.Resolve<CalculatorViewModel>();

	        var mainView = inflater.Inflate(Resource.Layout.standard_calculator_fragment, container, false);
	        GetViews(mainView);

	        return mainView;

	    }

	    public override void OnPause()
	    {
	        base.OnPause();
	        _equals.Click -= EqualsOnClick;
	        _btn0.Click -= NumberButtonOnClick;
	        _btn1.Click -= NumberButtonOnClick;
	        _btn2.Click -= NumberButtonOnClick;
	        _btn3.Click -= NumberButtonOnClick;
	        _btn4.Click -= NumberButtonOnClick;
	        _btn5.Click -= NumberButtonOnClick;
	        _btn6.Click -= NumberButtonOnClick;
	        _btn7.Click -= NumberButtonOnClick;
	        _btn8.Click -= NumberButtonOnClick;
	        _btn9.Click -= NumberButtonOnClick;
	        _plus.Click -= PlusOnClick;
	        _viewModel.PropertyChanged -= ViewModelOnPropertyChanged;
	    }

        public override void OnResume()
	    {
	        base.OnResume();
            _equals.Click += EqualsOnClick;
	        _btn0.Click += NumberButtonOnClick;
	        _btn1.Click += NumberButtonOnClick;
	        _btn2.Click += NumberButtonOnClick;
	        _btn3.Click += NumberButtonOnClick;
	        _btn4.Click += NumberButtonOnClick;
	        _btn5.Click += NumberButtonOnClick;
	        _btn6.Click += NumberButtonOnClick;
	        _btn7.Click += NumberButtonOnClick;
	        _btn8.Click += NumberButtonOnClick;
	        _btn9.Click += NumberButtonOnClick;
	        _plus.Click += PlusOnClick;
            _viewModel.PropertyChanged += ViewModelOnPropertyChanged;
        }

	    private void ViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
	    {
	        if (propertyChangedEventArgs.PropertyName == nameof(_viewModel.Display))
	        {
	            _display.Text = _viewModel.Display;
	        }
        }

	    private void PlusOnClick(object sender, EventArgs eventArgs)
	    {
	        _viewModel.PressPlus();
	    }

        private void NumberButtonOnClick(object sender, EventArgs eventArgs)
	    {
	        var button = (Button)sender;
	        var buttonText = button.Text;
	        _viewModel.PressNumber(buttonText);
	    }

	    private void EqualsOnClick(object sender, EventArgs eventArgs)
	    {
            _viewModel.PressEquals();
	    }

        private void GetViews(Android.Views.View rootElement)
	    {
	        _equals = rootElement.FindViewById<Button>(Resource.Id.equals);
	        _btn0 = rootElement.FindViewById<Button>(Resource.Id.zero);
	        _btn1 = rootElement.FindViewById<Button>(Resource.Id.btn1);
	        _btn2 = rootElement.FindViewById<Button>(Resource.Id.btn2);
	        _btn3 = rootElement.FindViewById<Button>(Resource.Id.btn3);
	        _btn4 = rootElement.FindViewById<Button>(Resource.Id.btn4);
	        _btn5 = rootElement.FindViewById<Button>(Resource.Id.btn5);
	        _btn6 = rootElement.FindViewById<Button>(Resource.Id.btn6);
	        _btn7 = rootElement.FindViewById<Button>(Resource.Id.btn7);
	        _btn8 = rootElement.FindViewById<Button>(Resource.Id.btn8);
	        _btn9 = rootElement.FindViewById<Button>(Resource.Id.btn9);
	        _plus = rootElement.FindViewById<Button>(Resource.Id.plus);
	        _display = rootElement.FindViewById<TextView>(Resource.Id.display);
	    }
	}
}


