using System.Collections.Generic;
using CircuitBuilder.Ports;

namespace CircuitBuilder
{
    public interface ICircuit
    {
        bool Start(List<IPort> ports);
        InputParser parser { get; set; }
    }
}