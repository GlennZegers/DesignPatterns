﻿using System.Collections.Generic;

namespace CircuitBuilder
{
    public class OrPort : IPort
    {
        public string NodeIdentifier { get; set; }
        public List<IPort> PreviousPorts { get; set; }
        public List<IPort> NextPorts { get; set; }
    }
}