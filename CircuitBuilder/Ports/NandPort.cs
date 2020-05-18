using System.Collections.Generic;

namespace CircuitBuilder.Ports
{
    public class NandPort : IPort
    {
        public List<bool> Input { get; set; }
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
        }
        public void CalculateOutput(bool input)
        {
            this.Input.Add(input);
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
                foreach (var nextPort in this.NextPorts)
                {
                    nextPort.CalculateOutput(output);
                }
            }
        }
    }
}