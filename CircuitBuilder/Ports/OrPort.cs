using System.Collections.Generic;
using CircuitBuilder.Visitors;

namespace CircuitBuilder.Ports
{
    public class OrPort : IPort
    {
        public List<bool> Input { get; set; }
        public int MinimalInputCount { get; }
        public bool Output { get; set; }

        public bool IsStartPort { get; set; }
        public string NodeIdentifier { get; set; }
        public List<IPort> PreviousPorts { get; set; }
        public List<IPort> NextPorts { get; set; }
        public OrPort()
        {
            PreviousPorts = new List<IPort>();
            NextPorts = new List<IPort>();
            Input = new List<bool>();
            IsStartPort = false;
            MinimalInputCount = 2;
        }
        public void CalculateOutput(bool input)
        {
            this.Input.Add(input);
            // If port received all input, start calculating
            if (this.Input.Count == this.PreviousPorts.Count)
            {
                var output = false;
                foreach (var b in this.Input)
                {
                    if (b)
                    {
                        output = true;
                    }
                }
                this.Output = output;
                foreach (var nextPort in this.NextPorts)
                {
                    nextPort.CalculateOutput(output);
                }
            }
        }

        public void Accept(IPortVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}