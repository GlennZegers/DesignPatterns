using System.Collections.Generic;
using CircuitBuilder.Ports;

namespace CircuitBuilder
{
    public class NextCircuit : ICircuit
    {
        public InputParser parser { get; set; }
        public bool Start(List<IPort> ports)
        {
            var output = false;
            foreach (var port in ports)
            {
                // Find first port, start calculating output
                if (port.IsStartPort)
                {
                    port.CalculateOutput(true);
                }

                if (port.NodeIdentifier == "Cout")
                {
                    output = port.Output;
                }
            }

            return output;
        }
    }
}