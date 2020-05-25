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
        private IBuilder _builder;

        public InputParser(IView view)
        {
            _view = view;
            _getFileInput();
        }

        private void _getFileInput()
        {
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

        public bool ChangeNode(string nodeName, string input)
        {
            foreach (var node in _nodes)
            {
                if (node[0] == nodeName)
                {
                    node[0] = nodeName;
                    node[1] = input;

                    return true;
                }
            }

            return false;
        }

        private void _createPortList()
        {
            _builder = new CircuitBuilder();
            
            foreach (var n in _nodes)
            {
                _builder.AddPort(n[0], n[1]);
            }
            _builder.ConnectPorts(_edges);
            _ports = _builder.GetPorts();
        }

        //niet meer nodig?
        private IPort _parseNode(string[] input)
        { 
            PortFactory portFactory = new PortFactory();
            IPort port = portFactory.GetPort(input[1]);
            port.NodeIdentifier = input[0];

            return port;

        }

        public IBuilder GetBuilder()
        {
            return _builder;
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