using System.Collections.Generic;
using CircuitBuilder.Ports;

namespace CircuitBuilder
{
    public interface IBuilder
    {
        void AddPort(string nodeIdentifier, string portType);
        void ConnectPorts(Dictionary<string, string[]> edges);
        List<IPort> GetPorts();
    }
}