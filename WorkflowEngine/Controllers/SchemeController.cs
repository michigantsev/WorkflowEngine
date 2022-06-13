using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkflowEngine.Models;

namespace WorkflowEngine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchemeController : Controller
    {
        private WorflowEngineContext db = new WorflowEngineContext();
        // Post: SchemeController
        [HttpPost]
        public ObjectResult PostScheme(Scheme scheme)
        {
            List<AbstractSchemePart> dbContext = new List<AbstractSchemePart>();
            SchemeDB schemeDB = new SchemeDB();
            schemeDB.SchemeId = int.Parse(scheme.SchemeId);
            schemeDB.CurrentState = int.Parse(scheme.CurrentState);
            foreach (var p in scheme.SchemeParts)
            {
                switch (p.Type)
                {
                    case "State":
                        var statePart = new State();
                        statePart.Name = p.ObjName;
                        statePart.PartId = int.Parse(p.PartID);
                        statePart.NextIds = p.NextIDs.Select(int.Parse).ToList();
                        statePart.SchemeId = int.Parse(scheme.SchemeId);
                        dbContext.Add(statePart);
                        break;
                    case "Start":
                        var startPart = new Start();
                        startPart.PartId = int.Parse(p.PartID);
                        startPart.NextIds = p.NextIDs.Select(int.Parse).ToList();
                        startPart.SchemeId = int.Parse(scheme.SchemeId);
                        dbContext.Add(startPart);
                        break;
                    case "End":
                        var endPart = new End();
                        endPart.PartId = int.Parse(p.PartID);                      
                        endPart.SchemeId = int.Parse(scheme.SchemeId);
                        dbContext.Add(endPart);
                        break;
                    case "Gate":
                        var gatePart = new Gate();
                        gatePart.PartId = int.Parse(p.PartID);
                        gatePart.NextIds = p.NextIDs.Select(int.Parse).ToList();
                        gatePart.SchemeId = int.Parse(scheme.SchemeId);
                        gatePart.Conditions = p.Conditions;
                        dbContext.Add(gatePart);
                        break;                  
                }
                
            }
            return Ok(scheme);
        }
    }
}
