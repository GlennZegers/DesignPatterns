using System.Collections.Generic;
using System.IO;
using CircuitBuilder.InputReaders;
using CircuitBuilder.Ports;

namespace CircuitBuilder
{
    public class InputParser
    {
        private IView _view;
        private Dictionary<string, string[]> _edges;
        private List<string[]> _nodes;
        private List<IPort> _ports;

        public InputParser()
        {
            _getFileInput();
        }

        private void _getFileInput()
        {
            _view = new ConsoleView();
            var path = _view.GetInputFromUser();
            
            var extension = Path.GetExtension(path);
            
            InputReaderFactory inputReaderFactory = new InputReaderFactory();
            IInputReader inputReader = inputReaderFactory.GetInputReader(extension);
            
            inputReader.Read(path);
            _nodes = inputReader.CreateNodeList();
            _edges = inputReader.CreateEdgeList();
        }

        public void ParseInput()
        {
            _createPortList();
        }

        private void _createPortList()
        {
            _ports = new List<IPort>();
            
            foreach (var n in _nodes)
            {
                _ports.Add(_parseNode(n));
            }
        }

        private IPort _parseNode(string[] input)
        { 
            PortFactory portFactory = new PortFactory();
            IPort port = portFactory.GetPort(input[1]);
            port.NodeIdentifier = input[0];

            return port;

        }

        public Dictionary<string, string[]> GetEdges()
        {
            return _edges;
        }

        public List<IPort> GetPorts()
        {
            return _ports;
        }
    }
}