using System;
using System.Collections.Generic;
using Foundation;
using MobileCalc.ViewModels;
using MobileCalc.Views;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace MobileCalc.iOS.Views
{
    public class MenuViewController : UITableViewController
    {
        private const string ReuseIdentifier = "PageId";

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var mainDrawerViewModel = new MainDrawerViewModel();
            TableView.RegisterClassForCellReuse(typeof(UITableViewCell), ReuseIdentifier);
            TableView.DataSource = new PagesTableSource(mainDrawerViewModel.PageNames);
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var newContentView = GetPageFromIndex(indexPath);
            RootViewController.GetInstance().ChangeContentView(newContentView);
            tableView.DeselectRow(indexPath, true);
        }

        private static UIViewController GetPageFromIndex(NSIndexPath indexPath)
        {
            if (indexPath.Row == 0)
            {
                return new StandardCalculatorViewController();
            }
            var currencyView = new CurrencyView().CreateViewController();
            return currencyView;
        }

        public class PagesTableSource : UITableViewDataSource
        {
            private readonly List<string> _pages;

            public PagesTableSource(List<string> pages)
            {
                _pages = pages;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return _pages.Count;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var page = _pages[indexPath.Row];
                var cell = tableView.DequeueReusableCell(ReuseIdentifier);
                cell.TextLabel.Text = page;
                return cell;
            }
        }
    }
}