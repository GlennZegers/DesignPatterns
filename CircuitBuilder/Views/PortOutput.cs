using System.Collections.Generic;
using CircuitBuilder.Ports;
using CircuitBuilder.Visitors;

namespace CircuitBuilder.Views
{
    public class PortOutput : IConsoleView
    {
        public void Print(List<IPort> ports, Application application)
        {
            var portOutputVisitor = new PortOutputVisitor();

            foreach (var port in ports)
            {
                port.Accept(portOutputVisitor);
            }
        }
    }
}