using System.Collections.Generic;

namespace CircuitBuilder.Ports
{
    // Factory pattern
    public class PortFactory
    {
        public IPort GetPort(string portType)
        {
            switch (portType)
            {
                case "INPUT_HIGH":
                    return new InputHighPort();
                case "INPUT_LOW":
                    return new InputLowPort();
                case "PROBE":
                    return new ProbePort();
                case "OR":
                    return new OrPort();
                case "AND":
                    return new AndPort();
                case "NOT":
                    return new NotPort();
                case "NAND":
                    return new NandPort();
                case "NOR":
                    return new NorPort();
                case "XOR":
                    return new XorPort();
                default:
                    return null;
            }
        }
    }
}