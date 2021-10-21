using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ScanApp.db.Database;
using ScanApp.Web.Services;
using ScanAppWeb.Models;

namespace ScanAppWeb.Pages
{
    public class ExceptionsModel : PageModel
    {
        public readonly ExContext _context;

        public List<ExViewModel> ExceptionsDB = new();
        public List<AppViewModel> AppDb = new();

        public ExceptionsModel(ExContext context)
        {
            _context = context;
        }


        public JsonResult OnPostRead([DataSourceRequest] DataSourceRequest request)
        {
            if (!ExceptionsDB.Any())
            {
                var service = new ExceptionService();
                ExceptionsDB.AddRange(service.Read());
            }
            return new JsonResult(ExceptionsDB.ToDataSourceResult(request));
        }

        public JsonResult OnPostDestroy([DataSourceRequest] DataSourceRequest request, ExViewModel e)
        {
            _context.Exceptions.Remove(_context.Exceptions.FirstOrDefault(x => x.ExceptionId == e.ExceptionId));
            _context.SaveChanges();
            return new JsonResult(new[] { e }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult AppList([DataSourceRequest] DataSourceRequest request)
        {
            if (!AppDb.Any())
            {
                var service = new AppService();
                AppDb.AddRange(service.Read());
            }
            return new JsonResult(ExceptionsDB.ToDataSourceResult(request));
        }


    }
}
