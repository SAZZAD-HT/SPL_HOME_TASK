using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using SPL_HOME_TASK.Models;
using System.Data.SqlClient;

namespace SPL_HOME_TASK.Controllers
{
    public class DocumentCategoryInfoController : Controller
    {
        private readonly SPLEntities _context;

        public DocumentCategoryInfoController()
        {
            _context = new SPLEntities();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetCategories()
        {
            var categories = _context.DocumentCategoryInfoes.ToList();
            return Json(categories, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Create(DocumentCategoryInfo category)
        {
            try
            {
                int lastId = 0;

                string connectionString = "Data Source=TRIFO\\SQLEXPRESS;Initial Catalog=SPL;Integrated Security=True;;Application Name=EntityFramework"; // Replace with your actual connection string
                SqlConnection connection = new SqlConnection(connectionString);
                
                    connection.Open();

                    // Retrieve the last ID from the table
                    string query = "SELECT MAX(CategoryId) FROM DocumentCategoryInfo"; // Replace YourTableName with the actual table name
                    SqlCommand command = new SqlCommand(query, connection);
                    object result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        lastId = Convert.ToInt32(result);
                    }

                    // Increment the last ID by 1
                    int newId = lastId + 1;

                   category.CategoryId = newId; 



                
                _context.DocumentCategoryInfoes.Add(category);
                _context.SaveChanges();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpGet]
        public JsonResult GetCategoryById(int id)
        {
            var category = _context.DocumentCategoryInfoes.FirstOrDefault(c => c.CategoryId == id);
            return Json(category, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(DocumentCategoryInfo category)
        {
            try
            {
                var existingCategory = _context.DocumentCategoryInfoes.FirstOrDefault(c => c.CategoryId == category.CategoryId);
                if (existingCategory != null)
                {
                    existingCategory.CategoryName = category.CategoryName;
                    existingCategory.Description = category.Description;
                    existingCategory.Status = category.Status;

                    _context.SaveChanges();

                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, error = "Category not found" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                var category = _context.DocumentCategoryInfoes.FirstOrDefault(c => c.CategoryId == id);
                if (category != null)
                {
                    _context.DocumentCategoryInfoes.Remove(category);
                    _context.SaveChanges();

                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, error = "Category not found" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
