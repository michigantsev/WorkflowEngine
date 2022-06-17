using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WorkflowEngine.Models;
using WorkflowEngine.Models.JSONModels;

namespace WorkflowEngine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExternalController : Controller
    {
        private WorflowEngineContext db = new WorflowEngineContext();
        [HttpPost]
        public ObjectResult PostExternalQuery(ExternalQuery externalQuery)
        {
            if (externalQuery.CommandType == "GoTo")
            {
                var scheme = db.Schemes.First(i => i.SchemeId == int.Parse(externalQuery.SchemeID));

                scheme.CurrentState = db.NextIds.First(i => i.SchemeId == int.Parse(externalQuery.SchemeID) && i.PartId == scheme.CurrentState).PartId;

                db.SaveChanges();
            }
            else
            {
                var scheme = db.Schemes.First(i => i.SchemeId == int.Parse(externalQuery.SchemeID));
                RequestToParser(scheme);
            }
            return Ok(externalQuery);
        }

        private void RequestToParser(SchemeDB scheme)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://parser");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {

                foreach(var cond in db.Conditions)
                {
                    string json = $"\"SchemeID\":\"{cond.SchemeId}\"," +
                                  $"\"PartID\":\"{cond.PartId}\"" +
                                  $"\"Condition1\":\"{cond.Condition1}\"";

                    streamWriter.Write(json);

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                    }
                }
            }
        }
    }
}
