using System.Collections.Generic;
using CircuitBuilder.Visitors;

namespace CircuitBuilder.Ports
{
    public class NotPort : IPort
    {
        public List<bool> Input { get; set; }
        public bool Output { get; set; }
        public bool IsStartPort { get; set; }
        public string NodeIdentifier { get; set; }
        public List<IPort> PreviousPorts { get; set; }
        public List<IPort> NextPorts { get; set; }
        public NotPort()
        {
            PreviousPorts = new List<IPort>();
            NextPorts = new List<IPort>();
            Input = new List<bool>();
            IsStartPort = false;
        }
        public void CalculateOutput(bool input)
        {
            this.Output = !input;
            foreach (var nextPort in this.NextPorts)
            {
                nextPort.CalculateOutput(!input);
            }
        }

        public void Accept(IPortVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}