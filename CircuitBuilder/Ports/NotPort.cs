using System.Collections.Generic;

namespace CircuitBuilder.Ports
{
    public class NotPort : IPort
    {
        public List<bool> Input { get; set; }
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
            foreach (var nextPort in this.NextPorts)
            {
                nextPort.CalculateOutput(!input);
            }
        }
    }
}