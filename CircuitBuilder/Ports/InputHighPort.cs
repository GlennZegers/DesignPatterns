using System.Collections.Generic;

namespace CircuitBuilder
{
    public class InputHighPort : IPort
    {
        public InputHighPort()
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
            foreach (var nextPort in NextPorts)
            {
                nextPort.CalculateOutput(true);
            }
        }
    }
}