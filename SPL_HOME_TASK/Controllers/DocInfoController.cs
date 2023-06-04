using SPL_HOME_TASK.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SPL_HOME_TASK.Controllers
{
    public class DocInfoController : Controller
    {
        // GET: DocInfo
        public ActionResult Index()
        {
            List<Documentinfo> documentInfoList = doc();
            return View(documentInfoList);
        }
        [HttpGet]
        public List<Documentinfo> doc()
        {
                string connectionString = "Data Source=TRIFO\\SQLEXPRESS;Initial Catalog=SPL;Integrated Security=True;;Application Name=EntityFramework"; // Replace with your actual connection string
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();

                string query = "SELECT di.DocumentIdentity,di.CategoryId,dc.CategoryName,di.DocumentReferenceName,di.DocumentDate,di.DocumentName,di.DocumentNameBangla,di.Description,di.Status,mdi.MetaIdentity,mdi.MetaName,mdi.MetaNameBangla,mdi.Description,fi.FileIdentity, fi.FileNo,fi.FileName,  fi.FileNameBangla,  fi.Description, fi.FilePath, fi.FileStatus FROM DocumentInformation di LEFT JOIN DocumentCategoryInfo dc ON di.CategoryId = dc.CategoryId LEFT JOIN MetaDataInformation mdi ON di.DocumentIdentity = mdi.DocumentIdentity LEFT JOIN FileInformation fi ON di.DocumentIdentity = fi.DocumentIdentity;";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                List<Documentinfo> documentInfoList = new List<Documentinfo>();

                while (reader.Read())
                {
                    Documentinfo documentInfo = new Documentinfo();
                    documentInfo.DocumentIdentity = Convert.ToInt32(reader["DocumentIdentity"]);
                    documentInfo.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                    documentInfo.CategoryName = reader["CategoryName"].ToString();
                    documentInfo.DocumentReferenceName = reader["DocumentReferenceName"].ToString();
                    documentInfo.DocumentDate = Convert.ToDateTime(reader["DocumentDate"]);
                    documentInfo.DocumentName = reader["DocumentName"].ToString();
                    documentInfo.DocumentNameBangla = reader["DocumentNameBangla"].ToString();
                    documentInfo.Description = reader["Description"].ToString();
                    documentInfo.Status = Convert.ToBoolean(reader["Status"]);
                    documentInfo.MetaIdentity = Convert.ToInt32(reader["MetaIdentity"]);
                    documentInfo.MetaName = reader["MetaName"].ToString();
                    documentInfo.MetaNameBangla = reader["MetaNameBangla"].ToString();
                    documentInfo.MetaDescription = reader["Description"].ToString();
                    documentInfo.FileIdentity = Convert.ToInt32(reader["FileIdentity"]);
                    documentInfo.FileNo = reader["FileNo"].ToString();
                    documentInfo.FileName = reader["FileName"].ToString();
                    documentInfo.FileNameBangla = reader["FileNameBangla"].ToString();
                    documentInfo.FileDescription = reader["Description"].ToString();
                    documentInfo.FilePath = reader["FilePath"].ToString();
                    documentInfo.FileStatus = reader["FileStatus"].ToString();

                    documentInfoList.Add(documentInfo);
                }


                reader.Close();
                connection.Close();
                return documentInfoList;

                //return Json(new { success = true, data = documentInfoList });
                //return Json(documentInfoList, JsonRequestBehavior.AllowGet);
                //}
                //catch (Exception ex)
                //{
                //    return Json(new { success = false, error = ex.Message });
                //}
            


    }
    } }