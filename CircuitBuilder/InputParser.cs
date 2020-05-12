using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CircuitBuilder.Properties;

namespace CircuitBuilder
{
    public class InputParser
    {
        private string[] _input;
        private PortFactory _portFactory;
        private IView _view;
        private IInputReader _inputReader;

        public InputParser()
        {
            GetPath();
        }

        private void GetPath()
        {
            _view = new ConsoleView();
            _inputReader = new TextFileReader();
            _input = _inputReader.Read(_view.GetInputFromUser());
        }

        public void ParseInput()
        {
            _splitFile();
        }

        private void _splitFile()
        {
            List<string> inputNodes = new List<string>();
            List<string> inputEdges = new List<string>();
            var areEdges = false;
            
            foreach (var s in _input)
            {
                if (s == "")
                {
                    areEdges = true;
                    continue;
                }
                
                if (_isComment(s))
                {
                    continue;
                }

                if (!areEdges)
                {
                    inputNodes.Add(s);
                }
                else
                {
                    inputEdges.Add(s);
                }
            }
            
            _createNodeList(inputNodes);
        }

        private void _createNodeList(List<string> nodes)
        {
            _portFactory = new PortFactory();
            List<IPort> ports = new List<IPort>();
            
            foreach (var n in nodes)
            {
                // IPort newPort = _parseNode(n);
                
                // if (newPort != null)
                // {
                Console.WriteLine(_parseNode(n));
                ports.Add(_parseNode(n));
                //}
            }

            foreach (var port in ports)
            {
                Console.WriteLine(port.GetType() + " " + port.NodeIdentifier);
            }
            // list naar circuitbuilder
        }

        private IPort _parseNode(string input)
        {
            // Remove all whitespaces and ;
            Regex.Replace(input, @"\s+", "");
            input = input.Replace(";", "");
            input = input.Replace(":", "");

            // Split by tab
            string[] inputParts = input.Split('\t');

            IPort port = _portFactory.GetPort(inputParts[1]);
            Console.WriteLine(inputParts[0] + " : " + inputParts[1]);
            port.NodeIdentifier = inputParts[0];
            Console.WriteLine(port.NodeIdentifier);

            return port;

        }

        private bool _isComment(string input)
        {
            return input.StartsWith("#");
        }
    }
}