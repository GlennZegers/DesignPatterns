using System;

namespace CircuitBuilder.Views
{
    public class ChangeNode
    {
        private InputParser _parser;
        
        public ChangeNode(InputParser parser)
        {
            _parser = parser;
        }
        
        public void Print()
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
                
                // When node is not found, this returns false
                validInput = _parser.ChangeNode(nodeInput[0], nodeInput[1]);
            }
        }
    }
}