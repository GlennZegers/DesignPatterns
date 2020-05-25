using CircuitBuilder.Ports;

namespace CircuitBuilder.Visitors
{
    public interface IPortVisitor
    {
        void Visit(AndPort port);
        void Visit(InputHighPort port);
        void Visit(InputLowPort port);
        void Visit(NandPort port);
        void Visit(NorPort port);
        void Visit(NotPort port);
        void Visit(OrPort port);
        void Visit(ProbePort port);
        void Visit(XorPort port);
    }
}