using CircuitBuilder.Ports;

namespace CircuitBuilder.Tests
{   
    using NUnit.Framework;
    [TestFixture]
    public class InpuHIghPortTest
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