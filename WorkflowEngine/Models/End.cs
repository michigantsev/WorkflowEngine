namespace WorkflowEngine.Models
{
    public class End : AbstractSchemePart
    {
        public override int SchemeId { get ; set; }
        public override int PartId { get; set; }
        public override List<int> NextIds { get; set; }
    }
}
