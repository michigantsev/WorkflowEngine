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
            SchemeDB schemeDB = new SchemeDB();
            schemeDB.SchemeId = int.Parse(scheme.SchemeId);
            schemeDB.CurrentState = int.Parse(scheme.CurrentState);
            foreach (var p in scheme.Attributes)
            {
                AttributeDB attr = new AttributeDB();
                attr.SchemeId = int.Parse(scheme.SchemeId);
                attr.AttributeName = p.Name;
                attr.AttributeValue = p.Value;
                db.Attributes.Add(attr);
            }
            foreach (var p in scheme.SchemeParts)
            {
                SchemePartDB sPart = new SchemePartDB();
                sPart.SchemeId = int.Parse(scheme.SchemeId);
                sPart.PartName = p.ObjName;
                sPart.PartId = int.Parse(p.PartID);
                sPart.Type = int.Parse(p.Type);

                foreach (var x in p.NextIDs)
                {
                    NextIdDB next = new NextIdDB();
                    next.SchemeId = int.Parse(scheme.SchemeId);
                    next.PartId = sPart.PartId;
                    next.NextId1 = int.Parse(x);
                    db.NextIds.Add(next);
                }

                switch (sPart.Type)
                {
                    case (int)PartTypes.Gate:
                        foreach (var x in p.Conditions)
                        {
                            ConditionDB con = new ConditionDB();
                            con.SchemeId = int.Parse(scheme.SchemeId);
                            con.PartId = sPart.PartId;
                            con.Condition1 = x.Cond;
                            db.Conditions.Add(con);
                        }
                    break;
                }

                db.SchemeParts.Add(sPart);
            }

            db.Schemes.Add(schemeDB);

            return Ok(scheme);
        }
    }
}
