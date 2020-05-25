using System.Collections.Generic;
using CircuitBuilder.Ports;

namespace CircuitBuilder
{
    public class Circuit
    {
        public void Start(List<IPort> ports)
        {
            foreach (var port in ports)
            {
                // Find first port, start calculating output there
                if (port.IsStartPort)
                {
                    port.CalculateOutput(true);
                }
            }
        }
    }
}