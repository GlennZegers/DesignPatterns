using System;
using System.Text.RegularExpressions;

namespace CircuitBuilder
{
    public class InputParser
    {
        private string[] _input;
        private PortFactory _portFactory;

        public InputParser()
        {
            InputReader inputReader = new TextFileReader();
            _input = inputReader.Read(@"D:\School\Documenten\Leerjaar 3\Blok 12\DP1\Circuits\Circuit1_FullAdder.txt");
        }

        public void ReadInput()
        {
            foreach (var s in _input)
            {
                _parseInput(s);
            }
        }

        private void _parseInput(string input)
        {
            if (_isComment(input))
            {
                return;
            }

            // Remove all whitespaces
            Regex.Replace(input, @"\s+", "");

            // Split by tab
            string[] inputParts = input.Split('\t');
            
            _portFactory = new PortFactory();
            _portFactory.CreatePort(inputParts[0], inputParts[1]);
        }

        private bool _isComment(string input)
        {
            return input.StartsWith("#");
        }
    }
}