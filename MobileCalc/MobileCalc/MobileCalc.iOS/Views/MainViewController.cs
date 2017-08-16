using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using MobileCalc.Services;
using MobileCalc.ViewModels;
using Praeclarum.UI;
using UIKit;

namespace MobileCalc.iOS.Views
{
    public class MainViewController : UIViewController
    {
        private readonly CalculatorViewModel _viewModel = ServiceContainer.Resolve<CalculatorViewModel>();

        private UIButton _plusMinusButton;
        private UILabel _mainLabel;
        private UIButton _zeroButton;
        private UIButton _dotButton;
        private UIButton _equalsButton;
        private UIButton _button1;
        private UIButton _button2;
        private UIButton _button3;
        private UIButton _buttonPlus;
        private UIButton _button4;
        private UIButton _button5;
        private UIButton _button6;
        private UIButton _buttonMinus;
        private UIButton _button7;
        private UIButton _button8;
        private UIButton _button9;
        private UIButton _buttonTimes;
        private UIButton _buttonCe;
        private UIButton _buttonC;
        private UIButton _buttonBackspace;
        private UIButton _buttonDivide;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.FromRGBA(236, 236, 236, 255);
            AddViews();
            AddConstraints();
        }

        private void AddConstraints()
        {
            View.ConstrainLayout(() => 
                _mainLabel.Frame.Top == View.Frame.Top + 40
                && _mainLabel.Frame.Left == View.Frame.Left + 50
                && _mainLabel.Frame.Right == View.Frame.Right - 15
                && _mainLabel.Frame.Height == View.Frame.Height * .167f - 44

                && _plusMinusButton.Frame.Bottom == View.Frame.Bottom
                && _plusMinusButton.Frame.Left == View.Frame.Left
                && _plusMinusButton.Frame.Width == View.Frame.Width * .25f - 4
                && _plusMinusButton.Frame.Height == View.Frame.Height * .167f - 4
                
                && _zeroButton.Frame.Bottom == View.Frame.Bottom
                && _zeroButton.Frame.Left == _plusMinusButton.Frame.Right + 4
                && _zeroButton.Frame.Width == _plusMinusButton.Frame.Width
                && _zeroButton.Frame.Height == _plusMinusButton.Frame.Height
                
                && _dotButton.Frame.Bottom == View.Frame.Bottom
                && _dotButton.Frame.Left == _zeroButton.Frame.Right + 4
                && _dotButton.Frame.Width == _plusMinusButton.Frame.Width
                && _dotButton.Frame.Height == _plusMinusButton.Frame.Height
                
                && _equalsButton.Frame.Bottom == View.Frame.Bottom
                && _equalsButton.Frame.Left == _dotButton.Frame.Right + 4
                && _equalsButton.Frame.Width == _plusMinusButton.Frame.Width
                && _equalsButton.Frame.Height == _plusMinusButton.Frame.Height

                && _button1.Frame.Bottom == _plusMinusButton.Frame.Top - 4
                && _button1.Frame.Left == View.Frame.Left
                && _button1.Frame.Width == _plusMinusButton.Frame.Width
                && _button1.Frame.Height == _plusMinusButton.Frame.Height

                && _button2.Frame.Bottom == _button1.Frame.Bottom
                && _button2.Frame.Left == _button1.Frame.Right + 4
                && _button2.Frame.Width == _plusMinusButton.Frame.Width
                && _button2.Frame.Height == _plusMinusButton.Frame.Height

                && _button3.Frame.Bottom == _button1.Frame.Bottom
                && _button3.Frame.Left == _button2.Frame.Right + 4
                && _button3.Frame.Width == _plusMinusButton.Frame.Width
                && _button3.Frame.Height == _plusMinusButton.Frame.Height

                && _buttonPlus.Frame.Bottom == _button1.Frame.Bottom
                && _buttonPlus.Frame.Left == _button3.Frame.Right + 4
                && _buttonPlus.Frame.Width == _plusMinusButton.Frame.Width
                && _buttonPlus.Frame.Height == _plusMinusButton.Frame.Height

                && _button4.Frame.Bottom == _button1.Frame.Top - 4
                && _button4.Frame.Left == View.Frame.Left
                && _button4.Frame.Width == _plusMinusButton.Frame.Width
                && _button4.Frame.Height == _plusMinusButton.Frame.Height
                
                && _button5.Frame.Bottom == _button4.Frame.Bottom
                && _button5.Frame.Left == _button4.Frame.Right + 4
                && _button5.Frame.Width == _plusMinusButton.Frame.Width
                && _button5.Frame.Height == _plusMinusButton.Frame.Height
                
                && _button6.Frame.Bottom == _button4.Frame.Bottom
                && _button6.Frame.Left == _button5.Frame.Right + 4
                && _button6.Frame.Width == _plusMinusButton.Frame.Width
                && _button6.Frame.Height == _plusMinusButton.Frame.Height
                
                && _buttonMinus.Frame.Bottom == _button4.Frame.Bottom
                && _buttonMinus.Frame.Left == _button6.Frame.Right + 4
                && _buttonMinus.Frame.Width == _plusMinusButton.Frame.Width
                && _buttonMinus.Frame.Height == _plusMinusButton.Frame.Height

                && _button7.Frame.Bottom == _button4.Frame.Top - 4
                && _button7.Frame.Left == View.Frame.Left
                && _button7.Frame.Width == _plusMinusButton.Frame.Width
                && _button7.Frame.Height == _plusMinusButton.Frame.Height
                
                && _button8.Frame.Bottom == _button7.Frame.Bottom
                && _button8.Frame.Left == _button7.Frame.Right + 4
                && _button8.Frame.Width == _plusMinusButton.Frame.Width
                && _button8.Frame.Height == _plusMinusButton.Frame.Height
                
                && _button9.Frame.Bottom == _button7.Frame.Bottom
                && _button9.Frame.Left == _button8.Frame.Right + 4
                && _button9.Frame.Width == _plusMinusButton.Frame.Width
                && _button9.Frame.Height == _plusMinusButton.Frame.Height

                && _buttonTimes.Frame.Bottom == _button7.Frame.Bottom
                && _buttonTimes.Frame.Left == _button9.Frame.Right + 4
                && _buttonTimes.Frame.Width == _plusMinusButton.Frame.Width
                && _buttonTimes.Frame.Height == _plusMinusButton.Frame.Height

                && _buttonCe.Frame.Bottom == _button7.Frame.Top - 4
                && _buttonCe.Frame.Left == View.Frame.Left
                && _buttonCe.Frame.Width == _plusMinusButton.Frame.Width
                && _buttonCe.Frame.Height == _plusMinusButton.Frame.Height

                && _buttonC.Frame.Bottom == _buttonCe.Frame.Bottom
                && _buttonC.Frame.Left == _buttonCe.Frame.Right + 4
                && _buttonC.Frame.Width == _plusMinusButton.Frame.Width
                && _buttonC.Frame.Height == _plusMinusButton.Frame.Height

                && _buttonBackspace.Frame.Bottom == _buttonCe.Frame.Bottom
                && _buttonBackspace.Frame.Left == _buttonC.Frame.Right + 4
                && _buttonBackspace.Frame.Width == _plusMinusButton.Frame.Width
                && _buttonBackspace.Frame.Height == _plusMinusButton.Frame.Height

                && _buttonDivide.Frame.Bottom == _buttonCe.Frame.Bottom
                && _buttonDivide.Frame.Left == _buttonBackspace.Frame.Right + 4
                && _buttonDivide.Frame.Width == _plusMinusButton.Frame.Width
                && _buttonDivide.Frame.Height == _plusMinusButton.Frame.Height

            );

        }

        private void AddViews()
        {
            _mainLabel = AddLabel(View, "0");

            _plusMinusButton = AddButton(View, "+=");
            _zeroButton = AddButton(View, "0");
            _dotButton = AddButton(View, ".");
            _equalsButton = AddButton(View, "=");

            _button1 = AddButton(View, "1");
            _button2 = AddButton(View, "2");
            _button3 = AddButton(View, "3");
            _buttonPlus = AddButton(View, "+");

            _button4 = AddButton(View, "4");
            _button5 = AddButton(View, "5");
            _button6 = AddButton(View, "6");
            _buttonMinus = AddButton(View, "-");

            _button7 = AddButton(View, "7");
            _button8 = AddButton(View, "8");
            _button9 = AddButton(View, "9");
            _buttonTimes = AddButton(View, "X");

            _buttonCe = AddButton(View, "CE");
            _buttonC = AddButton(View, "C");
            _buttonBackspace = AddButton(View, "<-");
            _buttonDivide = AddButton(View, "%");
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            _equalsButton.TouchUpInside += EqualsButtonOnTouchUpInside;
            _zeroButton.TouchUpInside += NumberButtonOnTouchUpInside;
            _button1.TouchUpInside += NumberButtonOnTouchUpInside;
            _button2.TouchUpInside += NumberButtonOnTouchUpInside;
            _button3.TouchUpInside += NumberButtonOnTouchUpInside;
            _button4.TouchUpInside += NumberButtonOnTouchUpInside;
            _button5.TouchUpInside += NumberButtonOnTouchUpInside;
            _button6.TouchUpInside += NumberButtonOnTouchUpInside;
            _button7.TouchUpInside += NumberButtonOnTouchUpInside;
            _button8.TouchUpInside += NumberButtonOnTouchUpInside;
            _button9.TouchUpInside += NumberButtonOnTouchUpInside;
        }

        private void NumberButtonOnTouchUpInside(object sender, EventArgs eventArgs)
        {
            var uiButton = (UIButton)sender;
            var number = uiButton.Title(UIControlState.Normal);
            _viewModel.PressNumber(number);
            _mainLabel.Text = _viewModel.Display;
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            _equalsButton.TouchUpInside -= EqualsButtonOnTouchUpInside;
            _zeroButton.TouchUpInside -= NumberButtonOnTouchUpInside;
            _button1.TouchUpInside -= NumberButtonOnTouchUpInside;
            _button2.TouchUpInside -= NumberButtonOnTouchUpInside;
            _button3.TouchUpInside -= NumberButtonOnTouchUpInside;
            _button4.TouchUpInside -= NumberButtonOnTouchUpInside;
            _button5.TouchUpInside -= NumberButtonOnTouchUpInside;
            _button6.TouchUpInside -= NumberButtonOnTouchUpInside;
            _button7.TouchUpInside -= NumberButtonOnTouchUpInside;
            _button8.TouchUpInside -= NumberButtonOnTouchUpInside;
            _button9.TouchUpInside -= NumberButtonOnTouchUpInside;
        }

        private int counter = 0;

        private void EqualsButtonOnTouchUpInside(object sender, EventArgs eventArgs)
        {
            counter++;
            _mainLabel.Text = counter.ToString();
        }

        private static UILabel AddLabel(UIView parent, string text)
        {
            var label = new UILabel();
            parent.AddSubview(label);
            label.Text = text;
            label.Font = UIFont.FromName(label.Font.Name, 40);
            label.TextAlignment = UITextAlignment.Right;
            label.BackgroundColor = UIColor.FromRGBA(237, 237, 237, 255);
            return label;
        }


        private static UIButton AddButton(UIView parent, string title)
        {
            var button = new UIButton();
            button.BackgroundColor = UIColor.FromRGBA(251, 251, 251, 255);
            button.SetTitleColor(UIColor.Black, UIControlState.Normal);
            button.SetTitle(title, UIControlState.Normal);
            parent.AddSubview(button);
            return button;
        }

    }
}