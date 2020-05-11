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

            InputParser inputParser = new InputParser();
            inputParser.ReadInput();

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            ConsoleView consoleView = new ConsoleView();
            TextFileReader textFileReader = new TextFileReader();
            textFileReader.Read(consoleView.GetInputFromUser());

        }
    }
}