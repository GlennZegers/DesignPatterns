using System;
using System.Collections.Generic;
using CircuitBuilder.Ports;

namespace CircuitBuilder
{
    public class CircuitBuilder :IBuilder
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
            foreach (var keyValuePair in edges)
            {
                var inputPort = _getPortFromList(keyValuePair.Key);
                foreach (var nodeTarget in keyValuePair.Value)
                {
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
                if (port.NextPorts.Count == 0)
                {
                    throw new Exception(port.NodeIdentifier + " is not connected to a port");
                }

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