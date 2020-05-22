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
            
            Application application = new Application(view);
            application.StartNewCircuit();
        }
    }
}