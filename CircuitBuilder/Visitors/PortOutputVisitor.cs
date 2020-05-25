using System;
using CircuitBuilder.Ports;

namespace CircuitBuilder.Visitors
{
    // Visitor pattern
    public class PortOutputVisitor : IPortVisitor
    {
        public void Visit(AndPort port)
        {
            var fullString = "Andport "+ port.NodeIdentifier +" receives ";
            foreach (var previousPort in port.PreviousPorts)
            {
                fullString += previousPort.Output + " from " + previousPort.NodeIdentifier + " ,";
            }

            fullString += "so output is: " + port.Output;
            Console.WriteLine(fullString);
        }

        public void Visit(InputHighPort port)
        {
            Console.WriteLine(port.NodeIdentifier + " outputs true");
        }

        public void Visit(InputLowPort port)
        {
            Console.WriteLine(port.NodeIdentifier + " outputs false");
        }

        public void Visit(NandPort port)
        {
            var fullString = "Nandport "+ port.NodeIdentifier +" receives ";
            foreach (var previousPort in port.PreviousPorts)
            {
                fullString += previousPort.Output + " from " + previousPort.NodeIdentifier + " ,";
            }

            fullString += "so output is: " + port.Output;
            Console.WriteLine(fullString);
        }

        public void Visit(NorPort port)
        {
            var fullString = "Norport "+ port.NodeIdentifier +" receives ";
            foreach (var previousPort in port.PreviousPorts)
            {
                fullString += previousPort.Output + " from " + previousPort.NodeIdentifier + " ,";
            }

            fullString += "so output is: " + port.Output;
            Console.WriteLine(fullString);
        }

        public void Visit(NotPort port)
        {
            var fullString = "Notport "+ port.NodeIdentifier +" receives ";
            foreach (var previousPort in port.PreviousPorts)
            {
                fullString += previousPort.Output + " from " + previousPort.NodeIdentifier + " ,";
            }

            fullString += "so output is: " + port.Output;
            Console.WriteLine(fullString);
        }

        public void Visit(OrPort port)
        {
            var fullString = "Orport "+ port.NodeIdentifier +" receives ";
            foreach (var previousPort in port.PreviousPorts)
            {
                fullString += previousPort.Output + " from " + previousPort.NodeIdentifier + " ,";
            }

            fullString += "so output is: " + port.Output;
            Console.WriteLine(fullString);
        }

        public void Visit(ProbePort port)
        {
            var fullString = "!RESULT! Probeport "+ port.NodeIdentifier +" receives ";
            foreach (var previousPort in port.PreviousPorts)
            {
                fullString += previousPort.Output + " from " + previousPort.NodeIdentifier + " ,";
            }

            fullString += "so output is: " + port.Output;
            Console.WriteLine(fullString);
        }

        public void Visit(XorPort port)
        {
            var fullString = "Xorport "+ port.NodeIdentifier +" receives ";
            foreach (var previousPort in port.PreviousPorts)
            {
                fullString += previousPort.Output + " from " + previousPort.NodeIdentifier + " ,";
            }

            fullString += "so output is: " + port.Output;
            Console.WriteLine(fullString);
        }
    }
}