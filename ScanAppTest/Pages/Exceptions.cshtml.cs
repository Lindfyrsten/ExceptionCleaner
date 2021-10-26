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


        public JsonResult OnPostRead([DataSourceRequest] DataSourceRequest request, int appid)
        {
            ExceptionsDB.Clear();
            var service = new ExceptionService();
            var e = service.ReadByAppId(appid);
            ExceptionsDB.AddRange(e);
            return new JsonResult(ExceptionsDB.ToDataSourceResult(request));
        }

        public JsonResult OnPostDestroy([DataSourceRequest] DataSourceRequest request, ExViewModel e)
        {
            _context.Exceptions.Remove(_context.Exceptions.FirstOrDefault(x => x.ExceptionId == e.ExceptionId));
            _context.SaveChanges();
            return new JsonResult(new[] { e }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult OnGetAppList([DataSourceRequest] DataSourceRequest request)
        {
            return new JsonResult(_context.Apps
                     .Select(c => new { AppId = c.AppId, AppName = c.Name }).OrderBy(o => o.AppName).ToList());
            //return new JsonResult(AppDb.ToDataSourceResult(request));
        }

        public ActionResult Get_Exceptions_By_Id([DataSourceRequest]DataSourceRequest request, int appid)
        {
            var service = new ExceptionService();
            var result = service.GetById(appid);
            //var result = _context.GetExceptionsByAppId(appid);
            return new JsonResult(result.ToDataSourceResult(request));
            
        }


    }
}
