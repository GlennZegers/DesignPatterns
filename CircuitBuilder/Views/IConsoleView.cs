using System.Collections.Generic;
using CircuitBuilder.Ports;

namespace CircuitBuilder.Views
{
    public interface IConsoleView
    {
        void Print(List<IPort> ports, Application application);
    }
}