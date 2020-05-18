using System;
using System.IO;

namespace CircuitBuilder
{
    public class ConsoleView : IView
    {
        public void Render()
        {
            throw new System.NotImplementedException();
        }

        public void RenderPort()
        {
            throw new System.NotImplementedException();
        }

        public void RenderOutput()
        {
            throw new System.NotImplementedException();
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