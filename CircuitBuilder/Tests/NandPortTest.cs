using CircuitBuilder.Ports;

namespace CircuitBuilder.Tests
{
    using NUnit.Framework;
    [TestFixture]
    public class NandPortTest
    {
        [Test]
        public void FalseAndTrue()
        {
            NandPort port = new NandPort();
            port.PreviousPorts.Add(new AndPort());
            port.PreviousPorts.Add(new AndPort());
            
            port.CalculateOutput(true);
            port.CalculateOutput(false);

            Assert.AreEqual(true, port.Output);
        }
        
        [Test]
        public void FalseAndFalse()
        {
            NandPort port = new NandPort();
            port.PreviousPorts.Add(new AndPort());
            port.PreviousPorts.Add(new AndPort());
            
            port.CalculateOutput(false);
            port.CalculateOutput(false);

            Assert.AreEqual(true, port.Output);
        }
        
        [Test]
        public void TrueAndTrue()
        {
            NandPort port = new NandPort();
            port.PreviousPorts.Add(new AndPort());
            port.PreviousPorts.Add(new AndPort());
            
            port.CalculateOutput(true);
            port.CalculateOutput(true);

            Assert.AreEqual(false, port.Output);
        }
        
        [Test]
        public void TrueTrueAndFalse()
        {
            NandPort port = new NandPort();
            port.PreviousPorts.Add(new AndPort());
            port.PreviousPorts.Add(new AndPort());
            port.PreviousPorts.Add(new AndPort());
            
            port.CalculateOutput(true);
            port.CalculateOutput(true);
            port.CalculateOutput(false);

            Assert.AreEqual(true, port.Output);
        }
    }
}