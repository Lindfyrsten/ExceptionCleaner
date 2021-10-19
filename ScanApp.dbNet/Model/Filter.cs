using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanApp.db.Model
{
    public class Filter
    {
        [Key]
        public int FilterId { get; set; }
        public string Value { get; set; }
        public string AppName { get; set; }
        
        public Filter() { }

        public Filter(string Value, string AppName)
        {
            this.Value = Value;
            this.AppName = AppName;
        }
    }
}
