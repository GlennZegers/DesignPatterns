using System;
using System.Collections.Generic;
using CircuitBuilder.Ports;

namespace CircuitBuilder
{
    public class Circuit
    {
        public void Build(Dictionary<string, string[]> edges, List<IPort> ports)
        {
            foreach (var keyValuePair in edges)
            {
                var inputPort = _getPortFromList(ports, keyValuePair.Key);
                foreach (var nodeTarget in keyValuePair.Value)
                {
                    var outputPort = _getPortFromList(ports, nodeTarget);
                    inputPort.NextPorts.Add(outputPort);
                    outputPort.PreviousPorts.Add(inputPort);
                }
            }
        }

        public void Start(List<IPort> ports)
        {
            foreach (var port in ports)
            {
                if (port.IsStartPort)
                {
                    port.CalculateOutput(true);
                }
            }
        }

        private IPort _getPortFromList(List<IPort> ports , string key)
        {    
            foreach (var port in ports)
            {
                if (port.NodeIdentifier.Equals(key))
                {
                    return port;
                }
            }

            return null;
        }
    }
}