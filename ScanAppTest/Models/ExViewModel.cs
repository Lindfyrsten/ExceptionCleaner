using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ScanAppWeb.Models
{
    public class ExViewModel
    {

         
        [ScaffoldColumn(false)]
        public int ExceptionId
        {
            get;
            set;
        }

        public int AppId {
            get;
            set;
        }

        [Display(Name = "Dato")]
        public string Date
        {
            get; set;
        }
        
        [Display(Name = "App")]
        public string AppName { get; set; }

        [Display(Name = "Log file")]
        public string FileName { get; set; }

        [Display(Name ="Exception")]
        public string ExMsg { get; set; }
    }
}
