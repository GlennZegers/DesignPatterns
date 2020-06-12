using System;
using CircuitBuilder.Ports;

namespace CircuitBuilder.Visitors
{
    // Visitor pattern
    public class PortOutputVisitor : IPortVisitor
    {
        public void Visit(IInputPort port)
        {
            Console.WriteLine(port.NodeIdentifier + " outputs " + port.Output);
        }

        public void Visit(INodePort port)
        {
            var fullString = port.GetType().Name + " " + port.NodeIdentifier + " receives ";
            foreach (var previousPort in port.PreviousPorts)
            {
                fullString += previousPort.Output + " from " + previousPort.NodeIdentifier + ", ";
            }

            fullString += "so output is: " + port.Output;
            Console.WriteLine(fullString);
        }

        public void Visit(IOutputPort port)
        {
            var fullString = "!RESULT! " + port.GetType().Name + " " + port.NodeIdentifier + " receives ";
            foreach (var previousPort in port.PreviousPorts)
            {
                fullString += previousPort.Output + " from " + previousPort.NodeIdentifier + ", ";
            }

            fullString += "so output is: " + port.Output;
            Console.WriteLine(fullString);
        }
        
    }
}