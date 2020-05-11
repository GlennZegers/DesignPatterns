using System.Collections.Generic;

namespace CircuitBuilder
{
    public class PortFactory
    {
        private Dictionary<string, IPort> _ports;
        public void CreatePort(string name, string portType)
        {
            _setPorts();
        }
        
        private void _setPorts()
        {
            _ports = new Dictionary<string, IPort>();

            _ports["INPUT_HIGH"] = new InputHighPort();
            _ports["INPUT_LOW"] = new InputLowPort();
            _ports["PROBE"] = new ProbePort();
            _ports["OR"] = new OrPort();
            _ports["AND"] = new AndPort();
            _ports["NOT"] = new NotPort();
            _ports["NAND"] = new NandPort();
            _ports["NOR"] = new NorPort();
            _ports["XOR"] = new XorPort();
        }
    }
}