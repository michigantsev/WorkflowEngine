namespace WorkflowEngine.Models
{
    public class Scheme
    {
        public string SchemeId { get; set; }
        public string SchemeName { get; set; }
        public List<Attribute> Attributes { get; set; }
        public string CurrentState { get; set; }
        public List<SchemePart> SchemeParts { get; set; }
    }

}
