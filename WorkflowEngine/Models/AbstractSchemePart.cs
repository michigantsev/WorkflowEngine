namespace WorkflowEngine.Models
{
    public abstract class AbstractSchemePart
    {
        public abstract int SchemeId { get; set; }
        public abstract int PartId { get; set; }
        public abstract List<int>? NextIds { get; set; }

    }
}
