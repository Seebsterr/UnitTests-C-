using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TestNinja.Mocking;

namespace TestNinjaUnitTests
{
    [TestFixture]
    public class BookingHelperTests
    {
        [Test]
        public void OverlappingBookingsExist_StatusIsCancelled_ReturnsEmptyString()
        {
            var booking = new Booking { Status = "Cancelled" };
            var result = BookingHelper.OverlappingBookingsExist(booking, new Mock<IBookingRepository>().Object);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void OverlappingBookingsExist_BookingIsNoOverlapping_ReturnsEmptyString()
        {
            var booking = new Booking { Id = 1 };
            var bookingRepo = new Mock<IBookingRepository>();
            bookingRepo.Setup(x => x.GetActiveBookings(booking.Id)).Returns(
                 new List<Booking>() { }.AsQueryable());
            var result = BookingHelper.OverlappingBookingsExist(booking, bookingRepo.Object);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void OverlappingBookingsExist_BookingIsOverlapping_ReturnsReference()
        {
            var expectedRef = "ref";
            var booking = new Booking
            { Reference = "reference", Id = 1, ArrivalDate = DateTime.MinValue, DepartureDate = DateTime.MaxValue };
            var bookingRepo = new Mock<IBookingRepository>();
            bookingRepo.Setup(x => x.GetActiveBookings(booking.Id)).Returns(new List<Booking>()
            { new Booking { Reference = expectedRef, Id = 1, ArrivalDate = DateTime.MinValue,
                DepartureDate = DateTime.MaxValue } }.AsQueryable());
            var result = BookingHelper.OverlappingBookingsExist(booking, bookingRepo.Object);

            Assert.AreEqual(expectedRef, result);
        }
    }
}
