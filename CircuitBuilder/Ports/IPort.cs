﻿using System.Collections.Generic;
using CircuitBuilder.Visitors;

namespace CircuitBuilder.Ports
{
    public interface IPort
    {
        List<bool> Input { get; set; }
        int MinimalInputCount { get; }
        bool Output { get; set; }
        bool IsStartPort { get; set; }
        bool IsEndPort { get; set; }
        string NodeIdentifier { get; set; }
        List<IPort> PreviousPorts  { get; set; }
        List<IPort> NextPorts  { get; set; }
        
        void CalculateOutput(bool input);

        // Visitor pattern
        void Accept(IPortVisitor visitor);
    }
}