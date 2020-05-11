using System.IO;

namespace CircuitBuilder
{
    public class TextFileReader : InputReader
    {
        public string[] Read(string path)
        {
            string[] result = File.ReadAllLines(path);
            foreach (string s in result)
            {
                System.Console.WriteLine(s);
            }
           
            return result;
        }
    }
}