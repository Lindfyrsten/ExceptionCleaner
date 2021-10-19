using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanApp.db.Model
{
    public class ScanInfo
    {
        [Key]
        public int ScanID { get; set; }
        public DateTime Date { get; set; }
        public int ExLast24H { get; set; }
        public int ExSinceLastScan { get; set; }

        public int ExTotal { get; set; }

        public ScanInfo()
        {

        }
        public ScanInfo(DateTime date, int exLast24H, int exSinceLastScan, int exTotal)
        {
            Date = date;
            ExLast24H = exLast24H;
            ExSinceLastScan = exSinceLastScan;
            ExTotal = exTotal;
        }
    }
}
