using CircuitBuilder.Ports;

namespace CircuitBuilder.Tests
{
    using NUnit.Framework;
    [TestFixture]
    public class XorPortTest
    {
        [Test]
        public void FalseAndTrue()
        {
            XorPort port = new XorPort();
            port.PreviousPorts.Add(new AndPort());
            port.PreviousPorts.Add(new AndPort());
            
            port.CalculateOutput(true);
            port.CalculateOutput(false);

            Assert.AreEqual(true, port.Output);
        }
        
        [Test]
        public void FalseAndFalse()
        {
            XorPort port = new XorPort();
            port.PreviousPorts.Add(new AndPort());
            port.PreviousPorts.Add(new AndPort());
            
            port.CalculateOutput(false);
            port.CalculateOutput(false);

            Assert.AreEqual(false, port.Output);
        }
        
        [Test]
        public void TrueAndTrue()
        {
            XorPort port = new XorPort();
            port.PreviousPorts.Add(new AndPort());
            port.PreviousPorts.Add(new AndPort());
            
            port.CalculateOutput(true);
            port.CalculateOutput(true);

            Assert.AreEqual(false, port.Output);
        }
        
        [Test]
        public void TrueTrueAndFalse()
        {
            XorPort port = new XorPort();
            port.PreviousPorts.Add(new AndPort());
            port.PreviousPorts.Add(new AndPort());
            port.PreviousPorts.Add(new AndPort());
            
            port.CalculateOutput(true);
            port.CalculateOutput(true);
            port.CalculateOutput(false);

            Assert.AreEqual(false, port.Output);
        }
    }
}