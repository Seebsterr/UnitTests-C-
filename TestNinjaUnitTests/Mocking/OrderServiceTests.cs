using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinjaUnitTests.Mocking
{
    [TestFixture]
    class OrderServiceTests
    {
        [Test]
        public void PlaceORder_WhenCalled_StoreTheOrder()
        {
            var storage = new Mock<IStorage>();
            var service = new OrderService(storage.Object);
            var order = new Order();

            service.PlaceOrder(order);

            storage.Verify(x => x.Store(order), Times.Once); 
        }
    }
}
