using System;
using System.Collections.Generic;

namespace WorkflowEngine
{
    public partial class AttributeDB
    {
        public int SchemeId { get; set; }
        public int AttributeId { get; set; }
        public string? AttributeValue { get; set; }
        public string? AttributeName { get; set; }
    }
}
