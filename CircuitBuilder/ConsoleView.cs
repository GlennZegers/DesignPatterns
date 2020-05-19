using System;
using System.Collections.Generic;
using System.IO;
using CircuitBuilder.Ports;
using CircuitBuilder.Visitors;

namespace CircuitBuilder
{
    public class ConsoleView : IView
    {
        public void RenderOutputs(List<IPort> ports)
        {
            var portOutputVisitor = new PortOutputVisitor();

            foreach (var port in ports)
            {
                port.Accept(portOutputVisitor);
            }
        }

        public string GetInputFromUser()
        {
            var validPath = false;
            var userInput = "";
            while (!validPath)
            {
                Console.WriteLine("Enter the path for your input file");
                userInput = Console.ReadLine();
                if (userInput != null && File.Exists(userInput))
                {
                    validPath = true;
                }
            }
            return userInput;
        }
    }
}