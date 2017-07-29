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

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.Green;
            AddViews();
            AddConstraints();
        }

        private void AddConstraints()
        {
            _mainLabel.TranslatesAutoresizingMaskIntoConstraints = false;

            var constraints = new[]
            {
                NSLayoutConstraint.Create(_mainLabel, NSLayoutAttribute.Top, NSLayoutRelation.Equal, View, NSLayoutAttribute.Top, 1, 40),
                NSLayoutConstraint.Create(_mainLabel, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 0),
                NSLayoutConstraint.Create(_mainLabel, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1, 0),
            };

            foreach (var constraint in constraints)
            {
                constraint.Priority = (float)UILayoutPriority.Required;
            }

            View.AddConstraints(constraints);

            //View.ConstrainLayout(() =>
            //    //_mainLabel.Frame.Top == View.Frame.Top + 40
            //    //&& _mainLabel.Frame.Left == View.Frame.Left
            //    //_mainLabel.Frame.Right == View.Frame.Right
            //    _mainButton.Frame.Bottom == View.Frame.Bottom
            //    && _mainButton.Frame.Left == View.Frame.Left
            //    && _mainButton.Frame.Right == View.Frame.Right
            //);

            //var constraint1 = View.Constraints[0];
            //var constraint2 = View.Constraints[1];
            //var constraint3 = View.Constraints[2];

            Console.WriteLine("Hello");

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
            button.SetTitle("My Button", UIControlState.Normal);
            parent.AddSubview(button);
            return button;
        }

    }
}