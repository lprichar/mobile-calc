using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MobileCalc.ViewModels
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        public string Display { get; set; }
        private int _currentNumber = 0;
        private int _storedNumber = 0;
        private string _display;

        public void PressEquals()
        {
            _currentNumber = _storedNumber + _currentNumber;
            UpdateDisplay();
        }

        public void PressClear()
        {
            _currentNumber = 0;
            UpdateDisplay();
        }

        public void PressNumber(string number)
        {
            PressNumber(int.Parse(number));
        }

        public void PressNumber(int number)
        {
            _currentNumber = _currentNumber * 10;
            _currentNumber = _currentNumber + number;
            UpdateDisplay();
        }

        public void PressPlus()
        {
            _storedNumber = _currentNumber;
            _currentNumber = 0;
        }

        private void UpdateDisplay()
        {
            Display = _currentNumber.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
