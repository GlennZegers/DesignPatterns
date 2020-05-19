using System;
using CircuitBuilder.Ports;

namespace CircuitBuilder.Visitors
{
    public class PortOutputVisitor : IPortVisitor
    {
        public void Visit(AndPort port)
        {
            Console.WriteLine("Andport: output: " + port.Output );
        }

        public void Visit(InputHighPort port)
        {
            Console.WriteLine("ihigh: output: " + port.Output);
        }

        public void Visit(InputLowPort port)
        {
            Console.WriteLine("ilow: output: " + port.Output);
        }

        public void Visit(NandPort port)
        {
            Console.WriteLine("nand: output: " + port.Output);
        }

        public void Visit(NorPort port)
        {
            Console.WriteLine("nor: output: " + port.Output);
        }

        public void Visit(NotPort port)
        {
            Console.WriteLine("not: output: " + port.Output);
        }

        public void Visit(OrPort port)
        {
            Console.WriteLine("or: output: " + port.Output);
        }

        public void Visit(ProbePort port)
        {
            Console.WriteLine("probe: output: " + port.Output);
        }

        public void Visit(XorPort port)
        {
            Console.WriteLine("xor: output: " + port.Output);
        }
    }
}