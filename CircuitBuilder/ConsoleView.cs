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

        public void UserMakesNextMove(Application app)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Press Q to quit this circuit and enter another file");
                Console.WriteLine("Press N to change an input node");
                Console.WriteLine("Or press Esc to quit program");
                
                var ch = Console.ReadKey(true).Key;
                switch (ch)
                {
                    case ConsoleKey.Q:
                        app.StartNewCircuit();
                        return;
                    case ConsoleKey.N:
                        _readNodeInput(app.GetInputParser());
                        app.ReGenerateCircuit();
                        return;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        return;
                }
            }
            
        }

        private void _readNodeInput(InputParser parser)
        {
            var validInput = false;

            while (!validInput)
            {
                Console.WriteLine();
                Console.WriteLine("Write the name of the input node, following a whitespace and then INPUT_HIGH or INPUT_LOW and press enter");
                Console.WriteLine("Example: A INPUT_HIGH");

                var userInput = Console.ReadLine();
                
                if (!userInput.Contains(" "))
                {
                    continue;
                }

                if (!userInput.Contains("INPUT_HIGH") && !userInput.Contains("INPUT_LOW"))
                {
                    continue;
                }

                string[] nodeInput = userInput.Split(' ');
                
                validInput = parser.ChangeNode(nodeInput[0], nodeInput[1]);
            }
        }
    }
}