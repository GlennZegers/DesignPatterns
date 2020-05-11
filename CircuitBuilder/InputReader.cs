using System;

namespace CircuitBuilder
{
    public interface IInputReader
    {
        string[] Read(string path);
    }
}