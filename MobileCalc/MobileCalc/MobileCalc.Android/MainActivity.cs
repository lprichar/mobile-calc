using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;

namespace MobileCalc.Droid
{
	[Activity (Label = "MobileCalc.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : AppCompatActivity
	{
		int count = 1;
	    private Button _equals;

	    protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);
			GetViews();
		}

	    protected override void OnPause()
	    {
	        base.OnPause();
	        _equals.Click -= EqualsOnClick;
	    }

        protected override void OnResume()
	    {
	        base.OnResume();
            _equals.Click += EqualsOnClick;
	    }

	    private void EqualsOnClick(object sender, EventArgs eventArgs)
	    {
            // todo: do something on equals
	        //button.Text = string.Format("{0} clicks!", count++);
	    }

        private void GetViews()
	    {
	        _equals = FindViewById<Button>(Resource.Id.equals);
	    }
	}
}


