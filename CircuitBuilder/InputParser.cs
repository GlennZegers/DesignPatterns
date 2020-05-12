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
            _createEdgesList(inputEdges);
        }

        private void _createNodeList(List<string> nodes)
        {
            List<IPort> ports = new List<IPort>();
            
            foreach (var n in nodes)
            {
                ports.Add(_parseNode(n));
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

            _portFactory = new PortFactory();
            IPort port = _portFactory.GetPort(inputParts[1]);
            port.NodeIdentifier = inputParts[0];

            return port;

        }

        private void _createEdgesList(List<string> edgesInput)
        {
            Dictionary<string, string[]> edges = new Dictionary<string, string[]>();
            
            foreach (var e in edgesInput)
            {
                _parseEdge(edges, e);
            }
        }

        private void _parseEdge(Dictionary<string, string[]> dictionary, string input)
        {
            // Remove all whitespaces and ; and :
            Regex.Replace(input, @"\s+", "");
            input = input.Replace(";", "");
            input = input.Replace(":", "");

            // Split by tab
            string[] inputParts = input.Split('\t');

            string nodeSource = inputParts[0];
            string[] nodeTargets = _createArrayTargets(inputParts[1]);

            dictionary[nodeSource] = nodeTargets;
        }

        private string[] _createArrayTargets(string input)
        {
            return input.Split(',');
        }

        private bool _isComment(string input)
        {
            return input.StartsWith("#");
        }
    }
}