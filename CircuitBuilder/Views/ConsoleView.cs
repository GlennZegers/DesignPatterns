using System.Collections.Generic;
using CircuitBuilder.Ports;

namespace CircuitBuilder.Views
{
    // Composite pattern
    public class ConsoleView : IConsoleView
    {
        private List<IConsoleView> _consoleViews;

        public ConsoleView()
        {
            _consoleViews = new List<IConsoleView>
            {
                new PortOutput(),
                new UserInput()
            };
        }

        public void Print(List<IPort> ports, Application application)
        {
            foreach (var consoleView in _consoleViews)
            {
                consoleView.Print(ports, application);
            }
        }
    }
}