using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MobileCalc.ViewModels;
using MobileCalc.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace MobileCalc.Droid.View
{
    [Activity(Label = "MobileCalc.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainDrawerActivity : AppCompatActivity, PageAdapter.IOnItemClickListener
    {
        private DrawerLayout mDrawerLayout;
        private RecyclerView mDrawerList;
        private ActionBarDrawerToggle mDrawerToggle;
        private MainDrawerViewModel _viewModel;

        private string mDrawerTitle;

        public MainDrawerActivity()
        {
            // todo: convert to service locator
            _viewModel = new MainDrawerViewModel();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Forms.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_navigation_drawer);
            mDrawerTitle = Title;
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mDrawerList = FindViewById<RecyclerView>(Resource.Id.left_drawer);

            // set a custom shadow that overlays the main content when the drawer opens
            mDrawerLayout.SetDrawerShadow(Resource.Drawable.drawer_shadow, GravityCompat.Start);
            // improve performance by indicating the list if fixed size.
            mDrawerList.HasFixedSize = true;
            mDrawerList.SetLayoutManager(new LinearLayoutManager(this));

            // set up the drawer's list view with items and click listener

            var pageAdapter = new PageAdapter(_viewModel.PageNames, this);
            mDrawerList.SetAdapter(pageAdapter);
            // enable ActionBar app icon to behave as action to toggle nav drawer
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // ActionBarDrawerToggle ties together the the proper interactions
            // between the sliding drawer and the action bar app icon

            mDrawerToggle = new MyActionBarDrawerToggle(this, mDrawerLayout,
                Resource.String.drawer_open,
                Resource.String.drawer_close);

            // todo: Set the hamburger menu image to Resource.Drawable.ic_drawer

            mDrawerLayout.SetDrawerListener(mDrawerToggle);
            if (savedInstanceState == null) //first launch
                SelectItem(0);

        }

        internal class MyActionBarDrawerToggle : ActionBarDrawerToggle
        {
            readonly MainDrawerActivity owner;

            public MyActionBarDrawerToggle(MainDrawerActivity activity, DrawerLayout layout, int openRes, int closeRes)
                : base(activity, layout, openRes, closeRes)
            {
                owner = activity;
            }

            public override void OnDrawerClosed(Android.Views.View drawerView)
            {
                owner.SupportActionBar.Title = owner.Title;
                owner.InvalidateOptionsMenu();
            }

            public override void OnDrawerOpened(Android.Views.View drawerView)
            {
                owner.SupportActionBar.Title = owner.mDrawerTitle;
                owner.InvalidateOptionsMenu();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            // Inflate the menu; this adds items to the action bar if it is present.
            this.MenuInflater.Inflate(Resource.Menu.navigation_drawer, menu);
            return true;
        }

        /* Called whenever we call invalidateOptionsMenu() */
        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            // todo: implement OnPrepareOptionsMenu

            //// If the nav drawer is open, hide action items related to the content view
            //bool drawerOpen = mDrawerLayout.IsDrawerOpen(mDrawerList);
            //menu.FindItem(Resource.Id.action_websearch).SetVisible(!drawerOpen);
            return base.OnPrepareOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            // The action bar home/up action should open or close the drawer.
            // ActionBarDrawerToggle will take care of this.
            if (mDrawerToggle.OnOptionsItemSelected(item))
            {
                return true;
            }
            // Handle action buttons
            switch (item.ItemId)
            {
                case Resource.Id.action_websearch:
                    // create intent to perform web search for this planet
                    Intent intent = new Intent(Intent.ActionWebSearch);
                    intent.PutExtra(SearchManager.Query, this.SupportActionBar.Title);
                    // catch event that there's no activity to handle intent
                    if (intent.ResolveActivity(this.PackageManager) != null)
                    {
                        StartActivity(intent);
                    }
                    else
                    {
                        Toast.MakeText(this, Resource.String.app_not_available, ToastLength.Long).Show();
                    }
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        /* The click listener for RecyclerView in the navigation drawer */
        public void OnClick(Android.Views.View view, int position)
        {
            SelectItem(position);
        }

        private void SelectItem(int position)
        {
            // todo: don't use the position, instead pass in the fragment to instantiate on click

            var fragment = GetFragment(position, this);

            var fragmentManager = SupportFragmentManager;
            var transaction = fragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.content_frame, fragment);
            transaction.Commit();

            // update selected item title, then close the drawer
            Title = "Hello World";
            mDrawerLayout.CloseDrawer(mDrawerList);
        }

        private static Android.Support.V4.App.Fragment GetFragment(int position, Context context)
        {
            if (position == 0)
                return new StandardCalculatorFragment();

            return new CurrencyView().CreateSupportFragment(context);
        }

        protected override void OnTitleChanged(Java.Lang.ICharSequence title, Android.Graphics.Color color)
        {
            //base.OnTitleChanged (title, color);
            SupportActionBar.Title = title.ToString();
        }

        /**
	     * When using the ActionBarDrawerToggle, you must call it during
	     * onPostCreate() and onConfigurationChanged()...
	     */

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            // Sync the toggle state after onRestoreInstanceState has occurred.
            mDrawerToggle.SyncState();
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            // Pass any configuration change to the drawer toggls
            mDrawerToggle.OnConfigurationChanged(newConfig);
        }
    }
}


