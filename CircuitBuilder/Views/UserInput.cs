using System;
using System.Collections.Generic;
using CircuitBuilder.Ports;

namespace CircuitBuilder.Views
{
    public class UserInput : IConsoleView
    {
        public void Print(List<IPort> ports, Application application)
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
                    // Start new circuit with new file
                    case ConsoleKey.Q:
                        application.StartNewCircuit();
                        return;
                    // Change node in current circuit
                    case ConsoleKey.N:
                        var changeNode = new ChangeNode(application.GetInputParser());
                        changeNode.Print();
                        application.ReGenerateCircuit();
                        return;
                    // Quit application
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        return;
                }
            }
        }
    }
}