using System.Collections.Generic;
using CircuitBuilder.Visitors;

namespace CircuitBuilder.Ports
{
    public class InputLowPort : IInputPort
    {
        public List<bool> Input { get; set; }
        public int MinimalInputCount { get; }
        public bool Output { get; set; }
        public bool IsEndPort { get; set; }
        public string NodeIdentifier { get; set; }
        public List<IPort> PreviousPorts { get; set; }
        public List<IPort> NextPorts { get; set; }
        public bool IsStartPort { get; set; }
        public InputLowPort()
        {
            PreviousPorts = new List<IPort>();
            NextPorts = new List<IPort>();
            Input = new List<bool>();
            IsStartPort = true;
            MinimalInputCount = 0;
            IsEndPort = false;
        }
        public void CalculateOutput(bool input)
        {
            this.Output = false;
            foreach (var nextPort in NextPorts)
            {
                nextPort.CalculateOutput(false);
            }
        }

        public void Accept(IPortVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}