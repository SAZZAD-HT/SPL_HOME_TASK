using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPL_HOME_TASK.Models
{
    public class Documentinfo
    {
        public long DocumentIdentity { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string DocumentReferenceName { get; set; }
        public DateTime DocumentDate { get; set; }
        public string DocumentName { get; set; }
        public string DocumentNameBangla { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public long MetaIdentity { get; set; }
        public string MetaName { get; set; }
        public string MetaNameBangla { get; set; }
        public string MetaDescription { get; set; }
        public long FileIdentity { get; set; }
        public string FileNo { get; set; }
        public string FileName { get; set; }
        public string FileNameBangla { get; set; }
        public string FileDescription { get; set; }
        public string FilePath { get; set; }
        public string FileStatus { get; set; }
    }
}