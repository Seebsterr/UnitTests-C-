using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinjaUnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        // lepiej rozbić to na 4/5 metod
        public void GetOutput_WhenCalled_ReturnsString()
        {
            var scenario0 = FizzBuzz.GetOutput(0);
            var scenario1 = FizzBuzz.GetOutput(15);
            var scenario2 = FizzBuzz.GetOutput(3);
            var scenario3 = FizzBuzz.GetOutput(5);
            var scenario4 = FizzBuzz.GetOutput(1);

            Assert.That(scenario0, Is.EqualTo("FizzBuzz"));
            Assert.That(scenario1, Is.EqualTo("FizzBuzz"));
            Assert.That(scenario2, Is.EqualTo("Fizz"));
            Assert.That(scenario3, Is.EqualTo("Buzz"));
            Assert.That(scenario4, Is.EqualTo("1"));
        }
    }
}
