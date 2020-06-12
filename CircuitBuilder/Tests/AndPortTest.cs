using CircuitBuilder.Ports;

namespace CircuitBuilder.Tests
{
    using NUnit.Framework;
    [TestFixture]
    public class AndPortTest
    {
        [Test]
        public void FalseAndTrue()
        {
            AndPort port = new AndPort();
            port.PreviousPorts.Add(new AndPort());
            port.PreviousPorts.Add(new AndPort());
            
            port.CalculateOutput(true);
            port.CalculateOutput(false);

            Assert.AreEqual(false, port.Output);
        }
        
        [Test]
        public void TrueAndTrue()
        {
            AndPort port = new AndPort();
            port.PreviousPorts.Add(new AndPort());
            port.PreviousPorts.Add(new AndPort());
            
            port.CalculateOutput(true);
            port.CalculateOutput(true);

            Assert.AreEqual(true, port.Output);
        }

        [Test]
        public void TrueTrueAndFalse()
        {
            AndPort port = new AndPort();
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