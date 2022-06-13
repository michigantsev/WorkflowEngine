using System.ComponentModel.DataAnnotations;

namespace WorkflowEngine.Models
{
   public class SchemePart
   {
        [Required]
        public string PartID { get; set; }
        public string? Type { get; set; }
        public List<string>? NextIDs { get; set; }
        public string? ObjName { get; set; }
        public List<Condition>? Conditions { get; set; }
   }
}
