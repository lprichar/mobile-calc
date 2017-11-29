using System;
using System.Collections.Generic;
using Foundation;
using MobileCalc.ViewModels;
using UIKit;

namespace MobileCalc.iOS.Views
{
    public class MenuViewController : UITableViewController
    {
        private const string ReuseIdentifier = "PageId";

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var mainDrawerViewModel = new MainDrawerViewModel();
            TableView.Source = new PagesTableSource(mainDrawerViewModel.PageNames);
            TableView.RegisterClassForCellReuse(typeof(UITableViewCell), ReuseIdentifier);
        }

        public class PagesTableSource : UITableViewSource
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