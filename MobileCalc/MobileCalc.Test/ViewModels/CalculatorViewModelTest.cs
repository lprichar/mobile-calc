using MobileCalc.ViewModels;
using NUnit.Framework;

namespace MobileCalc.Test.ViewModels
{
    [TestFixture]
    public class CalculatorViewModelTest
    {
        [Test]
        public void GivenStartup_WhenPressEquals_ThenDisplayIsZero()
        {
            var calculatorViewModel = new CalculatorViewModel();
            calculatorViewModel.PressEquals();
            Assert.AreEqual("0", calculatorViewModel.Display);
        }

        [Test]
        public void GivenStartup_WhenPressOneAsString_ThenDisplayIsOne()
        {
            var calculatorViewModel = new CalculatorViewModel();
            calculatorViewModel.PressNumber("1");
            Assert.AreEqual("1", calculatorViewModel.Display);
        }

        [Test]
        public void GivenStartup_WhenPressOne_ThenDisplayIsOne()
        {
            var calculatorViewModel = new CalculatorViewModel();
            calculatorViewModel.PressNumber(1);
            Assert.AreEqual("1", calculatorViewModel.Display);
        }

        [Test]
        public void GivenOneOnDisplay_WhenPressOneAgain_ThenDisplayIsEleven()
        {
            var calculatorViewModel = new CalculatorViewModel();
            calculatorViewModel.PressNumber(1);
            calculatorViewModel.PressNumber(1);
            Assert.AreEqual("11", calculatorViewModel.Display);
        }

        [Test]
        public void GivenOneOnDisplay_WhenPressClear_ThenDisplayIsZero()
        {
            var calculatorViewModel = new CalculatorViewModel();
            calculatorViewModel.PressNumber(1);
            calculatorViewModel.PressClear();
            Assert.AreEqual("0", calculatorViewModel.Display);
        }

        [Test]
        public void GivenOneOnDisplay_WhenPressClearThenPressOne_ThenDisplayIsOne()
        {
            var calculatorViewModel = new CalculatorViewModel();
            calculatorViewModel.PressNumber(1);
            calculatorViewModel.PressClear();
            calculatorViewModel.PressNumber(1);
            Assert.AreEqual("1", calculatorViewModel.Display);
        }

        [Test]
        public void GivenOnePlus_WhenPressOne_ThenDisplayOne()
        {
            var calculatorViewModel = new CalculatorViewModel();
            calculatorViewModel.PressNumber(1);
            calculatorViewModel.PressPlus();
            calculatorViewModel.PressNumber(1);
            Assert.AreEqual("1", calculatorViewModel.Display);
        }

        [Test]
        public void GivenOnePlusOne_WhenPressEquals_ThenDisplayTwo()
        {
            var calculatorViewModel = new CalculatorViewModel();
            calculatorViewModel.PressNumber(1);
            calculatorViewModel.PressPlus();
            calculatorViewModel.PressNumber(1);
            calculatorViewModel.PressEquals();
            Assert.AreEqual("2", calculatorViewModel.Display);
        }

        [Test]
        public void GivenOnePlusOne_WhenPressPlus_ThenDisplayTwo()
        {
            var calculatorViewModel = new CalculatorViewModel();
            calculatorViewModel.PressNumber(1);
            calculatorViewModel.PressPlus();
            calculatorViewModel.PressNumber(1);
            calculatorViewModel.PressPlus();
            Assert.AreEqual("2", calculatorViewModel.Display);
        }

        [Test]
        public void GivenOnePlusOnePlus_WhenPressOne_ThenDisplayOne()
        {
            var calculatorViewModel = new CalculatorViewModel();
            calculatorViewModel.PressNumber(1);
            calculatorViewModel.PressPlus();
            calculatorViewModel.PressNumber(1);
            calculatorViewModel.PressPlus();
            calculatorViewModel.PressNumber(1);
            Assert.AreEqual("1", calculatorViewModel.Display);
        }
    }
}
