using TestNinja.Fundamentals;
using NUnit.Framework;

namespace TestNinjaUnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_AdminCancelling_ReturnsTrue()
        {
            var user = new User() { IsAdmin = true };
            var reservation = new Reservation();

            var result = reservation.CanBeCancelledBy(user);

            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancellBy_SameUserCancelling_ReturnsTrue()
        {
            var user = new User();
            var reservation = new Reservation() { MadeBy = user };

            var result = reservation.CanBeCancelledBy(user);

            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancellBy_AnotherUserCancelling_ReturnsFalse()
        {
            var user = new User();
            var reservation = new Reservation();

            var result = reservation.CanBeCancelledBy(user);

            Assert.IsFalse(result);
        }
    }
}
