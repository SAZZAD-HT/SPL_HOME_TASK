using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace SPL_HOME_TASK.Models
{
    public class DocumentInformation
    {
        public long DocumentIdentity { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }

        [Display(Name = "Reference Name")]
        [Required(ErrorMessage = "Reference Name is required")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Reference Name must be between 3 and 150 characters")]
        public string DocumentReferenceName { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime DocumentDate { get; set; }

        [Display(Name = "Document Name")]
        [Required(ErrorMessage = "Document Name is required")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Document Name must be between 3 and 250 characters")]
        public string DocumentName { get; set; }

        [Display(Name = "Document Name (Bangla)")]
        [StringLength(500, ErrorMessage = "Document Name (Bangla) cannot exceed 500 characters")]
        public string DocumentNameBangla { get; set; }

        [StringLength(1500, ErrorMessage = "Description cannot exceed 1500 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public bool Status { get; set; }
    }
}