using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanApp.db.Model
{
    public class Exception
    {
        [Key]
        public int ExceptionId { get; set; }
        public int AppId { get; set; }
        public int Index { get; set; }
        public DateTime Date { get; set; }
        public string ExMsg { get; set; }
        public string PreLines { get; set; }
        [StringLength(256)]
        public string FileName { get; set; }

        public Exception(int AppId,int Index, string ExMsg, DateTime Date, string PreLines, string FileName)
        {
            this.AppId = AppId;
            this.Index = Index;
            this.ExMsg = ExMsg;
            this.Date = Date;
            this.PreLines = PreLines;
            this.FileName = FileName;
        }

        public Exception()
        {

        }
    }
}
