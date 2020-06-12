using System.Collections.Generic;

namespace CircuitBuilder.InputReaders
{
    // Strategy pattern
    public interface IInputReader
    {
        void Read(string path);
        List<string[]> CreateNodeList();
        Dictionary<string, string[]> CreateEdgeList();
    }
}