using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinjaUnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            var errorLogger = new ErrorLogger();

            errorLogger.Log("error");

            Assert.That(errorLogger.LastError, Is.EqualTo("error"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_RaiseArgumentNullException(string error)
        {
            var errorLogger = new ErrorLogger();

            Assert.That(() => errorLogger.Log(error), Throws.ArgumentNullException);
        }

        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            var errorLogger = new ErrorLogger();
            var id = Guid.Empty;
            errorLogger.ErrorLogged += (sender, args) => { id = args; };

            errorLogger.Log("someError");

            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
