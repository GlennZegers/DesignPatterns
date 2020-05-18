using System.Collections.Generic;

namespace CircuitBuilder
{
    public class AndPort : IPort
    {
        public AndPort()
        {
            PreviousPorts = new List<IPort>();
            NextPorts = new List<IPort>();
            Input = new List<bool>();
        }

        public List<bool> Input { get; set; }
        public string NodeIdentifier { get; set; }
        public List<IPort> PreviousPorts { get; set; }
        public List<IPort> NextPorts { get; set; }
        public void CalculateOutput(bool input)
        {
            this.Input.Add(input);
            if (this.Input.Count == this.PreviousPorts.Count)
            {
                var output = true;
                foreach (var b in this.Input)
                {
                    if (!b)
                    {
                        output = false;
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