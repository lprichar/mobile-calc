namespace MobileCalc.ViewModels
{
    public class CalculatorViewModel : ViewModelBase
    {
        public string Display { get; private set; }
        private int _currentNumber = 0;
        private int _storedNumber = 0;

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
    }
}
