using SPL_HOME_TASK.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SPL_HOME_TASK.Controllers
{
    public class SPLController : Controller
    {
        private readonly SPLEntities _context;

        public SPLController()
        {
            _context = new SPLEntities();
        }
        public ActionResult Index()
        {
             

      

            return View();
        }
        [HttpGet]
        public JsonResult GetDocumentInfo()
        {
            var categories = _context.DocumentInformations.ToList();
            return Json(categories, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetMetaInfo()
        {
            var categories = _context.MetaDataInformations.ToList();
            return Json(categories, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetFileInfo()
        {
            var categories = _context.FileInformations.ToList();
            return Json(categories, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult CreateDocument (DocumentInformation info)
        {
            try
            {
                _context.DocumentInformations.Add(info);
                _context.SaveChanges();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult CreateMeta(MetaDataInformation info)
        {
            try
            {
                _context.MetaDataInformations.Add(info);
                _context.SaveChanges();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }
        [HttpPost]
        public ActionResult CreateFile(FileInformation info, HttpPostedFileBase file)
        {
            var db = new SPLEntities();
            if (file != null && file.ContentLength > 0)
            {

                

                var path = Server.MapPath("~/Uploded");
                var maxNumber = Directory.GetFiles(path)
                    .Select(f => Path.GetFileNameWithoutExtension(f))
                    .Where(f => f.StartsWith("pic"))
                    .Select(f => int.Parse(f.Substring(3)))
                    .DefaultIfEmpty(0)
                    .Max();
                var newFileName = $"file{maxNumber + 1}{Path.GetExtension(file.FileName)}";
                var fullPath = Path.Combine(path, newFileName);
                file.SaveAs(fullPath);
               info.FilePath= fullPath;
            }
            try
            {
                db.FileInformations.Add(info);
                db.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }
        [HttpPost]
        public ActionResult CreateFileWithInfo(FileInformation fileInfo, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                // Save the file to a specified location
                string fileName = Path.GetFileName(file.FileName);
                string filePath = Path.Combine(Server.MapPath("~/Uploded"), fileName);
                file.SaveAs(filePath);

                // Update the file information
                fileInfo.FileNo = fileInfo.FileNo;
                fileInfo.FileName = fileInfo.FileName;
                fileInfo.FileNameBangla = fileInfo.FileNameBangla;
                fileInfo.Description = fileInfo.Description;
                fileInfo.FileStatus = fileInfo.FileStatus;
                fileInfo.FilePath = filePath;

                // Save the file information in the database
                // Your code to save the fileInfo object to the database

                return Json(new { success = true, fileName = fileInfo.FileName });
            }

            return Json(new { success = false, error = "No file uploaded." });
        }
    }

}
      

       
    
