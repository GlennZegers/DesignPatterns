using System.Collections.Generic;

namespace CircuitBuilder
{
    public class InputHighPort : IPort
    {
        public string NodeIdentifier { get; set; }
        public List<IPort> PreviousPorts { get; set; }
        public List<IPort> NextPorts { get; set; }
    }
}