using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScanAppWeb.Models
{
    public class ScanInfoViewModel
    {
        [Display(Name = "Dato")]
        public DateTime Date { get; set; }
        
        public int Id { get; set; }


        [Display(Name = "Sidste 24 timer")]
        public int ExLast24H { get; set; }

        [Display(Name = "Siden sidste scan")]
        public int ExSinceLastScan { get; set; }

        [Display(Name = "I alt")]
        public int ExTotal { get; set; }
    }
}
