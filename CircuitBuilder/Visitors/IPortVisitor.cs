using CircuitBuilder.Ports;

namespace CircuitBuilder.Visitors
{
    public interface IPortVisitor
    {
        void Visit(IInputPort port);
        void Visit(INodePort port);
        void Visit(IOutputPort port);
    }
}