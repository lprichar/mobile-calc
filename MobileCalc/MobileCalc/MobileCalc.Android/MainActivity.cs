using System;

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
	[Activity (Label = "MobileCalc.Android", MainLauncher = true, Icon = "@drawable/icon")]
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
	    }

        protected override void OnResume()
	    {
	        base.OnResume();
            _equals.Click += EqualsOnClick;
	        _btn0.Click += NumberButtonOnClick;
	        _btn1.Click += NumberButtonOnClick;
	        _btn2.Click += NumberButtonOnClick;
	        _btn3.Click += NumberButtonOnClick;
        }

	    private void NumberButtonOnClick(object sender, EventArgs eventArgs)
	    {
	        var button = (Button)sender;
	        var buttonText = button.Text;
	        _viewModel.PressNumber(buttonText);
	        _display.Text = _viewModel.Display;
	    }

	    private void EqualsOnClick(object sender, EventArgs eventArgs)
	    {
            // todo: do something on equals
	        //button.Text = string.Format("{0} clicks!", count++);
	    }

        private void GetViews()
	    {
	        _equals = FindViewById<Button>(Resource.Id.equals);
	        _btn0 = FindViewById<Button>(Resource.Id.zero);
	        _btn1 = FindViewById<Button>(Resource.Id.btn1);
	        _btn2 = FindViewById<Button>(Resource.Id.btn2);
	        _btn3 = FindViewById<Button>(Resource.Id.btn3);
	        _display = FindViewById<TextView>(Resource.Id.display);
	    }
	}
}


