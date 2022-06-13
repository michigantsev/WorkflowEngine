/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorkflowEngine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExternalController : Controller
    {
        // GET: ExternalController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ExternalController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExternalController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExternalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExternalController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExternalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExternalController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExternalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
*/