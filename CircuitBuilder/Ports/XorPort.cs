﻿using System.Collections.Generic;

namespace CircuitBuilder
{
    public class XorPort : IPort
    {
        public XorPort()
        {
            PreviousPorts = new List<IPort>();
            NextPorts = new List<IPort>();
        }
        public string NodeIdentifier { get; set; }
        public List<IPort> PreviousPorts { get; set; }
        public List<IPort> NextPorts { get; set; }
    }
}