using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinjaUnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFoundClass()
        {
            var customerController = new CustomerController();

            var result = customerController.GetCustomer(0);

            Assert.That(result, Is.TypeOf<NotFound>());
        }

        [Test]
        public void GetCustomer_IdIsNotZero_ReturnOkClass()
        {
            var customerController = new CustomerController();

            var result = customerController.GetCustomer(1);

            Assert.That(result, Is.TypeOf<Ok>());
        }
    }
}
