using System.Collections.Generic;
using CircuitBuilder.Ports;

namespace CircuitBuilder
{
    public class CircuitConnector : ICircuit
    {
        private List<ICircuit> _circuits;

        public CircuitConnector(List<ICircuit> circuits)
        {
            _circuits = circuits;
        }

        public bool Start(List<IPort> ports)
        {
            foreach (var circuit in _circuits)
            {
                circuit.Start()
            }
        }
    }
}