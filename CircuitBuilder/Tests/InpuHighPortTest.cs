using CircuitBuilder.Ports;

namespace CircuitBuilder.Tests
{   
    using NUnit.Framework;
    [TestFixture]
    public class InpuHighPortTest
    {
        [Test]
        public void OutputIsTrue()
        {
            InputHighPort port = new InputHighPort();

            port.CalculateOutput(true);

            Assert.AreEqual(true, port.Output);
        }
    }
}