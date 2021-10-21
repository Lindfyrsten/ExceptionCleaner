using ScanApp.db.Database;
using ScanAppWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScanApp.Web.Services
{
    public class ScanService
    {
        public IEnumerable<ScanInfoViewModel> Read()
        {
            return GetAll();
        }

        public IList<ScanInfoViewModel> GetAll()
        {
            using (var db = new ExContext())
            {
                var result = db.ScanInfos.ToList().Select(scan =>
                {
                    return new ScanInfoViewModel
                    {
                        Id = scan.ScanID,
                        Date = scan.Date,
                        ExLast24H = scan.ExLast24H,
                        ExSinceLastScan = scan.ExSinceLastScan,
                        ExTotal = scan.ExTotal
                    };
                }).ToList();
                return result;
            }
        }
    }
}
