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

            Application application = new Application();
            application.StartNewCircuit();
        }
    }
}