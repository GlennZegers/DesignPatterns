using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace CircuitBuilder.InputReaders
{
    // Strategy pattern
    public class TextFileReader : IInputReader
    {
        private string[] _fileLines;
        private List<string> _nodes;
        private List<string> _edges;
        
        public void Read(string path)
        {
            _fileLines = File.ReadAllLines(path);
            _splitFile();
        }
        
        // Splitting file into nodes and edges part
        private void _splitFile()
        {
            _nodes = new List<string>();
            _edges = new List<string>();
            var areEdges = false;
            
            foreach (var s in _fileLines)
            {
                // When this is true, the file has reached the edges
                if (s == "")
                {
                    areEdges = true;
                    continue;
                }
                
                // Is comment
                if (s.StartsWith("#"))
                {
                    continue;
                }

                if (!areEdges)
                {
                    _nodes.Add(s);
                }
                else
                {
                    _edges.Add(s);
                }
            }
        }

        public List<string[]> CreateNodeList()
        {
            List<string[]> nodeList = new List<string[]>();
            foreach (var n in _nodes)
            {
                var inputParts = _cleanString(n);
                
                nodeList.Add(inputParts);
            }

            return nodeList;
        }

        public Dictionary<string, string[]> CreateEdgeList()
        {
            Dictionary<string, string[]> edgeList = new Dictionary<string, string[]>();
            foreach (var e in _edges)
            {
                var inputParts = _cleanString(e);

                string nodeSource = inputParts[0];
                string[] nodeTargets = inputParts[1].Split(',');
                edgeList[nodeSource] = nodeTargets;
            }

            return edgeList;
        }

        // Remove all unnecessary characters 
        private string[] _cleanString(string input)
        {
            Regex.Replace(input, @"\s+", "");
            input = input.Replace(";", "");
            input = input.Replace(":", "");
            input = input.Replace(" ", string.Empty);

            return input.Split('\t');
        }
    }
}