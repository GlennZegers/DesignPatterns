using System;
using System.Collections.Generic;

namespace CircuitBuilder.Ports
{
    public class ProbePort : IPort
    {
        public ProbePort()
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
            Console.WriteLine(this.NodeIdentifier + input);
        }
    }
}