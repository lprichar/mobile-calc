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

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _sidebarController = new SidebarController(this, new MainViewController(), new MenuViewController())
            {
                MenuLocation = MenuLocations.Left
            };
        }
    }
}
