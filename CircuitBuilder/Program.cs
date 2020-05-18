using System.Globalization;
using System.Threading;

namespace CircuitBuilder
{
    internal class Program
    {
        public static void Main(string[] args)
        {            
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

            InputParser inputParser = new InputParser();
            inputParser.ParseInput();
            
            Circuit circuit = new Circuit();
            var ports = inputParser.GetPorts();
            circuit.Build(inputParser.GetEdges(),ports);
            circuit.Start(ports);
        }
    }
}