using System.Collections.Generic;

namespace CircuitBuilder.Ports
{
    public interface IPort
    {
        List<bool> Input { get; set; }
        string NodeIdentifier { get; set; }
        List<IPort> PreviousPorts  { get; set; }
        List<IPort> NextPorts  { get; set; }
        void CalculateOutput(bool input);
    }
}