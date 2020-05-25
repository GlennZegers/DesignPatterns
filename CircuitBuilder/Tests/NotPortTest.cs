using CircuitBuilder.Ports;

namespace CircuitBuilder.Tests
{
    using NUnit.Framework;
    [TestFixture]
    public class NotPortTest
    {
        [Test]
        public void Flase()
        {
            NotPort port = new NotPort();
            port.PreviousPorts.Add(new AndPort());
            
            port.CalculateOutput(false);

            Assert.AreEqual(true, port.Output);
        }

        [Test]
        public void True()
        {
            NotPort port = new NotPort();
            port.PreviousPorts.Add(new AndPort());
            
            port.CalculateOutput(true);

            Assert.AreEqual(false, port.Output);
        }
    }
}