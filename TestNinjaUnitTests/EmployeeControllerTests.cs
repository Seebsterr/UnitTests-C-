using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinjaUnitTests
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        Mock<IEmployeeRepository> _repository;
        EmployeeController _controler;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IEmployeeRepository>();
            _controler = new EmployeeController(_repository.Object);
        }

        [Test]
        public void DeleteEmployee_WhenCalled_RedirectToActionEmployees()
        {
            var result = _controler.DeleteEmployee(1);

            Assert.That(result, Is.InstanceOf<ActionResult>());
        }

        [Test]
        public void DeleteEmployee_WhenCalled_RemoveEmployee()
        {
            _controler.DeleteEmployee(1);

            _repository.Verify(x => x.DeleteEmployee(1), Times.Once);
        }
    }
}
