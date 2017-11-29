using SidebarNavigation;
using UIKit;

namespace MobileCalc.iOS.Views
{
    public class RootViewController : UIViewController
    {
        private SidebarController _sidebarController;

        public void ToggleMenu()
        {
            _sidebarController.ToggleMenu();
        }

        public void ChangeContentView(UIViewController newContentView)
        {
            _sidebarController.ChangeContentView(newContentView);
        }

        public static RootViewController GetInstance()
        {
            var appDelegate = (AppDelegate)UIApplication.SharedApplication.Delegate;
            var rootViewController = (RootViewController)appDelegate.Window.RootViewController;
            return rootViewController;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _sidebarController = new SidebarController(this, new StandardCalculatorViewController(), new MenuViewController())
            {
                MenuLocation = MenuLocations.Left
            };
        }
    }
}
