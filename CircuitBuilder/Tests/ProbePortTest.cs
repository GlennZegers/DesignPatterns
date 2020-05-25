using CircuitBuilder.Ports;

namespace CircuitBuilder.Tests
{
    using NUnit.Framework;
    [TestFixture]
    public class ProbePortTest
    {
        [Test]
        public void False()
        {
            ProbePort port = new ProbePort();

            port.PreviousPorts.Add(new AndPort());
            
            port.CalculateOutput(false);

            Assert.AreEqual(false, port.Output);
        }
        
        [Test]
        public void True()
        {
            ProbePort port = new ProbePort();
            port.PreviousPorts.Add(new AndPort());
            
            port.CalculateOutput(true);

            Assert.AreEqual(true, port.Output);
        }
    }
}