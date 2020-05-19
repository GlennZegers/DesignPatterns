using System.Collections.Generic;
using CircuitBuilder.Visitors;

namespace CircuitBuilder.Ports
{
    public interface IPort
    {
        List<bool> Input { get; set; }
        bool Output { get; set; }
        bool IsStartPort { get; set; }
        string NodeIdentifier { get; set; }
        List<IPort> PreviousPorts  { get; set; }
        List<IPort> NextPorts  { get; set; }
        void CalculateOutput(bool input);

        void Accept(IPortVisitor visitor);
    }
}