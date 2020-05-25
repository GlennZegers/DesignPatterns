using System.Collections.Generic;
using System.IO;
using CircuitBuilder.InputReaders;
using CircuitBuilder.Ports;
using CircuitBuilder.Views;

namespace CircuitBuilder
{
    public class InputParser
    {
        private FileInput _fileInput;
        private Dictionary<string, string[]> _edges;
        private List<string[]> _nodes;
        private List<IPort> _ports;
        private IBuilder _builder;

        public InputParser(FileInput fileInput)
        {
            _fileInput = fileInput;
            _getFileInput();
        }
        
        private void _getFileInput()
        {
            var path = _fileInput.GetFileInput();
            
            var extension = Path.GetExtension(path);
            
            // Get input reader based on extension of given path
            InputReaderFactory inputReaderFactory = new InputReaderFactory();
            IInputReader inputReader = inputReaderFactory.GetInputReader(extension);
            
            // Get node and edge list from input reader
            inputReader.Read(path);
            _nodes = inputReader.CreateNodeList();
            _edges = inputReader.CreateEdgeList();
        }

        public void ParseInput()
        {
            _createPortList();
        }

        // Is called when user requested to change an input node
        public bool ChangeNode(string nodeName, string input)
        {
            foreach (var node in _nodes)
            {
                if (node[0] == nodeName)
                {
                    node[0] = nodeName;
                    node[1] = input;

                    // Returns true when succeeded
                    return true;
                }
            }

            // Returns false when node name does not exist
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

        public List<IPort> GetPorts()
        {
            return _ports;
        }
    }
}