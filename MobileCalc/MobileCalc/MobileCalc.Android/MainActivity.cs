using System;
using System.ComponentModel;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using MobileCalc.Services;
using MobileCalc.ViewModels;

namespace MobileCalc.Droid
{
	[Activity (Label = "MobileCalc.Android", MainLauncher = false, Icon = "@drawable/icon")]
	public class MainActivity : AppCompatActivity
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

	    protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            // todo: implement a splash screen and call Startup() from there
            StartupService.Startup();

		    _viewModel = ServiceContainer.Resolve<CalculatorViewModel>();

            SetContentView(Resource.Layout.Main);
			GetViews();
		}

	    protected override void OnPause()
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

        protected override void OnResume()
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

        private void GetViews()
	    {
	        _equals = FindViewById<Button>(Resource.Id.equals);
	        _btn0 = FindViewById<Button>(Resource.Id.zero);
	        _btn1 = FindViewById<Button>(Resource.Id.btn1);
	        _btn2 = FindViewById<Button>(Resource.Id.btn2);
	        _btn3 = FindViewById<Button>(Resource.Id.btn3);
	        _btn4 = FindViewById<Button>(Resource.Id.btn4);
	        _btn5 = FindViewById<Button>(Resource.Id.btn5);
	        _btn6 = FindViewById<Button>(Resource.Id.btn6);
	        _btn7 = FindViewById<Button>(Resource.Id.btn7);
	        _btn8 = FindViewById<Button>(Resource.Id.btn8);
	        _btn9 = FindViewById<Button>(Resource.Id.btn9);
	        _plus = FindViewById<Button>(Resource.Id.plus);
	        _display = FindViewById<TextView>(Resource.Id.display);
	    }
	}
}


