using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScanAppWeb.Models
{
    public class FilterViewModel
    {
        [Display(Name = "Value")]
        public string Value { get; set; }
        
        public int FilterId { get; set; }


        [Display(Name = "App")]
        public string AppName { get; set; }
    }
}
