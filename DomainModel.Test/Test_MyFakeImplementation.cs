using DomainModel.FakeInterfaces;
using NUnit.Framework;

namespace Tests
{
    public class Test_MyFakeImplementation
    {
        [Test]
        public void TheSumIsCorrect()
        {
            var instance = new MyFakeImplementation();
            var a = 2;
            var b = 3;

            var sum = instance.Sum(a, b);

            Assert.That(sum, Is.EqualTo(5));
        }

        [Test]
        public void WorksWithNegatives()
        {
            var instance = new MyFakeImplementation();
            var a = -2;
            var b = -3;

            var sum = instance.Sum(a, b);

            Assert.That(sum, Is.EqualTo(-5));
        }

        [Test]
        public void WorksWithAZero()
        {
            var instance = new MyFakeImplementation();
            var a = 10;
            var b = 0;

            var sum = instance.Sum(a, b);

            Assert.That(sum, Is.EqualTo(10));
        }
    }
}