using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ScanAppWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using ScanApp.db.Database;
using ScanApp.Web.Services;

namespace ScanAppWeb.Pages
{
    public class IndexModel : PageModel
    {
        public readonly ExContext _context;
        private static List<AppViewModel> appsDB = new();
        public string Message { get; set; }

        public IndexModel(ExContext context)
        {
            _context = context;
        }

        public JsonResult OnPostRead([DataSourceRequest] DataSourceRequest request)
        {
            if (!appsDB.Any())
            {
                var service = new AppService();
                appsDB.AddRange(service.Read());
            }
            return new JsonResult(appsDB.ToDataSourceResult(request));
        }
    }
}
