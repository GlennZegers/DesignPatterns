using CircuitBuilder.Ports;

namespace CircuitBuilder.Tests
{
    using NUnit.Framework;
    [TestFixture]
    public class InputLowPortTest
    {
        [Test]
        public void OutputIsFalse()
        {
            InputLowPort port = new InputLowPort();

            port.CalculateOutput(true);

            Assert.AreEqual(false, port.Output);
        }
    }
}