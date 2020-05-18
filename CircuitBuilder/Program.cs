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
            circuit.Build(inputParser.GetEdges(), inputParser.GetPorts());
        }
    }
}