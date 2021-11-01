using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScanApp.Web.Services;
using ScanAppWeb.Models;

namespace ScanApp.Web.Pages
{
    public class IndexModel : PageModel
    {

        public List<ScanInfoViewModel> Scans = new();
        public void OnGet()
        {
            if (!Scans.Any())
            {
                var service = new ScanService();
                Scans.AddRange(service.Read());
            }
        }

        public JsonResult OnPostRead([DataSourceRequest] DataSourceRequest request)
        {
            if (!Scans.Any())
            {
                var service = new ScanService();
                Scans.AddRange(service.Read());
            }
            return new JsonResult(Scans.ToDataSourceResult(request));
        }
        public List<int> ChartTotals()
        {
            List<int> ScanNumbers = new();
            foreach(var scan in Scans.OrderByDescending(m => m.Date))
            {
                ScanNumbers.Add(scan.ExTotal);
            }
            return ScanNumbers;
        }

        public List<string> ChartDates()
        {
            List<string> ScanDates = new();
            foreach(var scan in Scans.OrderByDescending(m => m.Date))
            {
                ScanDates.Add(scan.Date.ToShortDateString());
            }
            return ScanDates;
        }
    }
}
