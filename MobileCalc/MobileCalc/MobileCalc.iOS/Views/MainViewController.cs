using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using Praeclarum.UI;
using UIKit;

namespace MobileCalc.iOS.Views
{
    public class MainViewController : UIViewController
    {
        private UIButton _mainButton;
        private UILabel _mainLabel;

        public MainViewController()
        {
            View.BackgroundColor = UIColor.Green;
            AddViews();
            AddConstraints();
        }

        private void AddConstraints()
        {
            View.ConstrainLayout(() => 
                _mainLabel.Frame.Top == View.Frame.Top + 40
                && _mainLabel.Frame.Left == View.Frame.Left
                && _mainLabel.Frame.Right == View.Frame.Right
            );

        }

        private void AddViews()
        {
            _mainButton = AddButton(View);
            _mainLabel = AddLabel(View, "0");
        }

        private static UILabel AddLabel(UIView parent, string text)
        {
            var label = new UILabel();
            parent.AddSubview(label);
            label.Text = text;
            label.BackgroundColor = UIColor.Cyan;
            return label;
        }


        private static UIButton AddButton(UIView parent)
        {
            var button = new UIButton();
            parent.AddSubview(button);
            return button;
        }

    }
}