using System.IO;

namespace CircuitBuilder
{
    public class TextFileReader : IInputReader
    {
        public string[] Read(string path)
        {
            var result = File.ReadAllLines(path);
            foreach (var s in result)
            {
                System.Console.WriteLine(s);
            }
           
            return result;
        }
    }
}