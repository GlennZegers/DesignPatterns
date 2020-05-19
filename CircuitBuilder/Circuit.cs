using System;
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
                if (port.IsStartPort)
                {
                    port.CalculateOutput(true);
                }
            }
        }
    }
}