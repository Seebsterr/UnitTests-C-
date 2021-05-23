using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinjaUnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIsLessThanZeroOrMoreThanMaxSpeed_ReturnsDemeritPoints(int speed)
        {
            var calculator = new DemeritPointsCalculator();

            Assert.That(() => calculator.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [TestCase(65, 0)]
        [TestCase(30, 0)]
        [TestCase(70, 1)]
        public void CalculateDemeritPoints_SpeedIsMoreThanZeroAndLessThanMaxSpeed_ReturnsDemeritPoints(int speed, int expectedResult)
        {
            var calculator = new DemeritPointsCalculator();

            var result = calculator.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
