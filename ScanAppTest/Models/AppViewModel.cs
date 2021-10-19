using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScanAppWeb.Models
{
    public class AppViewModel
    {
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "ID")]
        public int AppId { get; set; }

        [Display(Name = "Exceptions")]
        public int AppExceptions { get; set; }

        [Display(Name = "Filters")]
        public int FilterCount { get; set; }

    }
}
