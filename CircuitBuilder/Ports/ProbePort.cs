﻿using System;
using System.Collections.Generic;
using CircuitBuilder.Visitors;

namespace CircuitBuilder.Ports
{
    public class ProbePort : IOutputPort
    {
        public List<bool> Input { get; set; }
        public int MinimalInputCount { get;}
        public bool Output { get; set; }
        public bool IsStartPort { get; set; }
        public bool IsEndPort { get; set; }
        public string NodeIdentifier { get; set; }
        public List<IPort> PreviousPorts { get; set; }
        public List<IPort> NextPorts { get; set; }
        public ProbePort()
        {
            PreviousPorts = new List<IPort>();
            NextPorts = new List<IPort>();
            Input = new List<bool>();
            IsStartPort = false;
            MinimalInputCount = 1;
            IsEndPort = true;
        }
        public void CalculateOutput(bool input)
        {
            this.Output = input;
        }

        public void Accept(IPortVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}