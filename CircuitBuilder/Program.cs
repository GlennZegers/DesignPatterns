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
            IView view = new ConsoleView();
            InputParser inputParser = new InputParser(view);
            inputParser.ParseInput();
            
            Circuit circuit = new Circuit();
            var ports = inputParser.GetPorts();
            circuit.Start(ports);
            view.RenderOutputs(ports);
        }
    }
}