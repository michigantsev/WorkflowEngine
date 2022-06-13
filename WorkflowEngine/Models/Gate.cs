namespace WorkflowEngine.Models
{
    public class Gate : AbstractSchemePart
    {
        public override int PartId { get; set; }
        public override List<int> NextIds { get; set; }
        public override int SchemeId { get; set; }
        public List<Condition>? Conditions { get; set; }
    }
}
