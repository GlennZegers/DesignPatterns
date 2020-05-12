using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using CircuitBuilder.Properties;

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