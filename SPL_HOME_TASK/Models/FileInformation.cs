//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SPL_HOME_TASK.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FileInformation
    {
        public long FileIdentity { get; set; }
        public long DocumentIdentity { get; set; }
        public string FileNo { get; set; }
        public string FileName { get; set; }
        public string FileNameBangla { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public string FileStatus { get; set; }
    
        public virtual DocumentInformation DocumentInformation { get; set; }
    }
}
