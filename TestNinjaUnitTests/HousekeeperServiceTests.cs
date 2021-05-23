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
    public class HousekeeperServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IStatementGenerator> _statementGenerator;
        private Mock<IEmailSender> _emailSender;
        private IXtraMessageBox _xtraMessageBox;

        [SetUp]
        public void SetUp()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _emailSender = new Mock<IEmailSender>();
            _statementGenerator = new Mock<IStatementGenerator>();
        }

        [Test]
        public void SendStatementEmails_EmailIsEmpty_NotSentEmail()
        {
            _unitOfWork.Setup(x => x.Query<Housekeeper>()).Returns(new List<Housekeeper> { new Housekeeper() { Email = null } }.AsQueryable());

            var _service = new HousekeeperService(_unitOfWork.Object, _statementGenerator.Object, _emailSender.Object, _xtraMessageBox);
            _service.SendStatementEmails(DateTime.Now);

            _emailSender.Verify(x => x.EmailFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void SendStatementEmails_StatementFilenameIsNull_NotSentEmail()
        {
            _unitOfWork.Setup(x => x.Query<Housekeeper>()).Returns(new List<Housekeeper> { new Housekeeper() { Email = "email@gmail.com" } }.AsQueryable());
            _statementGenerator.Setup(x => x.SaveStatement(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>())).Returns("");

            var _service = new HousekeeperService(_unitOfWork.Object, _statementGenerator.Object, _emailSender.Object, _xtraMessageBox);
            _service.SendStatementEmails(DateTime.Now);

            _emailSender.Verify(x => x.EmailFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void SendStatementEmails_ArgsAreCorrect_SentEmail()
        {
            _unitOfWork.Setup(x => x.Query<Housekeeper>()).Returns(new List<Housekeeper> { new Housekeeper() { Email = "email@gmail.com" } }.AsQueryable());
            _statementGenerator.Setup(x => x.SaveStatement(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<DateTime>())).Returns("statement");

            var _service = new HousekeeperService(_unitOfWork.Object, _statementGenerator.Object, _emailSender.Object, _xtraMessageBox);
            _service.SendStatementEmails(DateTime.Now);

            _emailSender.Verify(x => x.EmailFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
