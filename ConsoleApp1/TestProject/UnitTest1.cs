namespace TestProject
{
    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestFermat()
        {
            Assert.IsTrue(Math.Pow(3, 3) + Math.Pow(4, 3) != Math.Pow(5, 3));
        }

        [Test]
        public void TestAddition()
        {
            Assert.AreEqual(2 + 2, 4);
        }

        [Test]
        public void TestSubtraction()
        {
            Assert.AreEqual(5 - 3, 2);
        }
    }

}