using System.Collections.Generic;
using CircuitBuilder.Ports;

namespace CircuitBuilder
{
    public interface IView
    {
        void RenderOutputs(List<IPort> ports);
        string GetInputFromUser();
    }
}