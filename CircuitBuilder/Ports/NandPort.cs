using System.Collections.Generic;
using CircuitBuilder.Visitors;

namespace CircuitBuilder.Ports
{
    public class NandPort : IPort
    {
        public List<bool> Input { get; set; }
        public int MinimalInputCount { get; }
        public bool Output { get; set; }
        public bool IsEndPort { get; set; }
        public string NodeIdentifier { get; set; }
        public List<IPort> PreviousPorts { get; set; }
        public List<IPort> NextPorts { get; set; }
        public bool IsStartPort { get; set; }

        public NandPort()
        {
            PreviousPorts = new List<IPort>();
            NextPorts = new List<IPort>();
            Input = new List<bool>();
            IsStartPort = false;
            MinimalInputCount = 2;
            IsEndPort = false;
        }
        public void CalculateOutput(bool input)
        {
            this.Input.Add(input);
            if (this.Input.Count == this.PreviousPorts.Count)
            {
                var allIsTrue = true;
                foreach (var b in this.Input)
                {
                    if (!b)
                    {
                        allIsTrue = false;
                    }
                }
                this.Output = !allIsTrue;
                foreach (var nextPort in this.NextPorts)
                {
                    nextPort.CalculateOutput(this.Output);
                }
            }
        }

        public void Accept(IPortVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}