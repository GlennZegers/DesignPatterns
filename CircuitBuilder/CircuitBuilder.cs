using System;
using System.Collections.Generic;
using CircuitBuilder.Ports;

namespace CircuitBuilder
{
    // Builder pattern
    public class CircuitBuilder : IBuilder
    {
        private List<IPort> _ports;
        private PortFactory _portFactory; 

        public CircuitBuilder()
        {
            this._ports = new List<IPort>();
        }
        
        public void AddPort(string nodeIdentifier, string portType)
        {
            this._portFactory = new PortFactory();
            var port = _portFactory.GetPort(portType);
            port.NodeIdentifier = nodeIdentifier;
            this._ports.Add(port);
        }

        public void ConnectPorts(Dictionary<string, string[]> edges)
        {
            // Go through all edges
            foreach (var keyValuePair in edges)
            {
                // Get port
                var inputPort = _getPortFromList(keyValuePair.Key);
                
                // Go through all targets of specific edge
                foreach (var nodeTarget in keyValuePair.Value)
                {
                    // Add previous and next targets to edge
                    var outputPort = _getPortFromList(nodeTarget);
                    inputPort.NextPorts.Add(outputPort);
                    outputPort.PreviousPorts.Add(inputPort);
                }
            }
        }

        public List<IPort> GetPorts()
        {
            _testPorts();
            return this._ports;
        }

        private void _testPorts()
        {
            foreach (var port in this._ports)
            {
                // Check if current port has more than one next port, if not, circuit is not connected
                if (port.NextPorts.Count == 0 && !port.IsEndPort)
                {
                    throw new Exception(port.NodeIdentifier + " is not connected to a port");
                }

                // Check if port has minimal one input, if not, circuit is not connected
                if (port.MinimalInputCount > port.PreviousPorts.Count)
                {
                    throw new Exception(port.NodeIdentifier + " should have at least " + port.MinimalInputCount + " input ports");
                }
            }

        }

        private IPort _getPortFromList( string key)
        {    
            foreach (var port in this._ports)
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