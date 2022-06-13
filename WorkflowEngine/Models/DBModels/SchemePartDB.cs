using System;
using System.Collections.Generic;

namespace WorkflowEngine
{
    public partial class SchemePartDB
    {
        public int SchemeId { get; set; }
        public int PartId { get; set; }
        public int Type { get; set; }
        public string? PartName { get; set; }
    }
}
