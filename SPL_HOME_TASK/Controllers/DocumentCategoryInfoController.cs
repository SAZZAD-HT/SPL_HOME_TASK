using SPL_HOME_TASK.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SPL_HOME_TASK.Controllers
{
    public class DocumentCategoryInfoController : Controller
    {
        private SPLEntities db = new SPLEntities();

        // GET: DocumentCategoryInfo
        public ActionResult Index()
        {
            return View();
        }

        // GET: DocumentCategoryInfo/GetCategories
        public ActionResult GetCategories()
        {
            var categories = db.DocumentCategoryInfoes.ToList();
            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        // POST: DocumentCategoryInfo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DocumentCategoryInfo documentCategoryInfo)
        {
            if (ModelState.IsValid)
            {
                db.DocumentCategoryInfoes.Add(documentCategoryInfo);
                await db.SaveChangesAsync();
                return Json(new { success = true });
            }

            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        // GET: DocumentCategoryInfo/GetCategoryById/5
        public ActionResult GetCategoryById(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DocumentCategoryInfo documentCategoryInfo = db.DocumentCategoryInfoes.Find(id);
            if (documentCategoryInfo == null)
            {
                return HttpNotFound();
            }

            return Json(documentCategoryInfo, JsonRequestBehavior.AllowGet);
        }

        // POST: DocumentCategoryInfo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(DocumentCategoryInfo documentCategoryInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentCategoryInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Json(new { success = true });
            }

            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        // POST: DocumentCategoryInfo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            DocumentCategoryInfo documentCategoryInfo = await db.DocumentCategoryInfoes.FindAsync(id);
            db.DocumentCategoryInfoes.Remove(documentCategoryInfo);
            await db.SaveChangesAsync();
            return Json(new { success = true });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
