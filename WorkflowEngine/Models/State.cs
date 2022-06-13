namespace WorkflowEngine.Models
{
    public class State : AbstractSchemePart
    {
        public override int PartId { get; set; }
        public override List<int> NextIds { get ; set; }
        public override int SchemeId { get ; set ; }
        public string Name { get; set; }
    }
}
