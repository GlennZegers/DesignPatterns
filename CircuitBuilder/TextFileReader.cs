using System.IO;

namespace CircuitBuilder
{
    public class TextFileReader : IInputReader
    {
        public string[] Read(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}