using System.Collections.Generic;

namespace CircuitBuilder
{
    public interface IPort
    {
        string NodeIdentifier { get; set; }
        List<IPort> PreviousPorts  { get; set; }
        List<IPort> NextPorts  { get; set; }
    }
}