using CircuitBuilder.Ports;

namespace CircuitBuilder.Tests
{
    using NUnit.Framework;
    [TestFixture]
    public class NorPortTest
    {
        [Test]
        public void FalseAndTrue()
        {
            NorPort port = new NorPort();
            port.PreviousPorts.Add(new AndPort());
            port.PreviousPorts.Add(new AndPort());
            
            port.CalculateOutput(true);
            port.CalculateOutput(false);

            Assert.AreEqual(false, port.Output);
        }
        
        [Test]
        public void FalseAndFalse()
        {
            NorPort port = new NorPort();
            port.PreviousPorts.Add(new AndPort());
            port.PreviousPorts.Add(new AndPort());
            
            port.CalculateOutput(false);
            port.CalculateOutput(false);

            Assert.AreEqual(true, port.Output);
        }
        
        [Test]
        public void TrueAndTrue()
        {
            NorPort port = new NorPort();
            port.PreviousPorts.Add(new AndPort());
            port.PreviousPorts.Add(new AndPort());
            
            port.CalculateOutput(true);
            port.CalculateOutput(true);

            Assert.AreEqual(false, port.Output);
        }
        
        [Test]
        public void TrueTrueAndFalse()
        {
            NorPort port = new NorPort();
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