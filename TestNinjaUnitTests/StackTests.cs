using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinjaUnitTests
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void Push_ObjectIsNull_ThrowException()
        {
            var stack = new Stack<object>();

            Assert.That(() => stack.Push(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Pop_ObjectIsNull_ThrowException()
        {
            var stack = new Stack<object>();

            Assert.That(() => stack.Pop(), Throws.Exception.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Peek_ObjectIsNull_ThrowException()
        {
            var stack = new Stack<object>();

            Assert.That(() => stack.Peek(), Throws.Exception.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Push_ObjectIsNotNull_StackCountIsOne()
        {
            var stack = new Stack<object>();

            stack.Push(new object());

            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Pop_ObjectIsNotNull_StackCountIsZero()
        {
            var stack = new Stack<object>();
            var sampleObj = new object();
            stack.Push(sampleObj);

            var result = stack.Pop();

            Assert.That(result, Is.EqualTo(sampleObj));
            Assert.That(stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Peek_ObjectIsNotNull_ReturnsObject()
        {
            var stack = new Stack<object>();
            var sampleObj = new object();
            stack.Push(sampleObj);

            var result = stack.Peek();

            Assert.That(result, Is.EqualTo(sampleObj));
            Assert.That(stack.Count, Is.GreaterThan(0));
        }
    }
}
