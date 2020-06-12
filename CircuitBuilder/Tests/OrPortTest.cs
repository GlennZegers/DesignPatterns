using CircuitBuilder.Ports;

namespace CircuitBuilder.Tests
{
    using NUnit.Framework;
    [TestFixture]
    public class OrPortTest
    {
        [Test]
        public void FalseAndTrue()
        {
            OrPort port = new OrPort();
            port.PreviousPorts.Add(new AndPort());
            port.PreviousPorts.Add(new AndPort());
            
            port.CalculateOutput(true);
            port.CalculateOutput(false);

            Assert.AreEqual(true, port.Output);
        }
        
        [Test]
        public void FalseAndFalse()
        {
            OrPort port = new OrPort();
            port.PreviousPorts.Add(new AndPort());
            port.PreviousPorts.Add(new AndPort());
            
            port.CalculateOutput(false);
            port.CalculateOutput(false);

            Assert.AreEqual(false, port.Output);
        }
        
        [Test]
        public void TrueAndTrue()
        {
            OrPort port = new OrPort();
            port.PreviousPorts.Add(new AndPort());
            port.PreviousPorts.Add(new AndPort());
            
            port.CalculateOutput(true);
            port.CalculateOutput(true);

            Assert.AreEqual(true, port.Output);
        }
        
        [Test]
        public void TrueTrueAndFalse()
        {
            OrPort port = new OrPort();
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