using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScanApp.db.Database;
using ScanApp.db.Model;
using ScanApp.Web.Services;
using ScanAppWeb.Models;
using Microsoft.AspNetCore.Http;

namespace ScanApp.Web.Pages.AppFilters
{
    public class IndexModel : PageModel
    {
        [FromRoute]
        public string AppName { get; set; }
        public List<FilterViewModel> filtersDB = new List<FilterViewModel>();

        public IndexModel()
        {
        }

        public void OnGet()
        {
            //var a = this.HttpContext.Session.GetString("login");
            HttpContext.Session.SetString("appname", AppName);
        }
        public JsonResult OnPostRead([DataSourceRequest] DataSourceRequest request)
        {
            var a = this.HttpContext.Session.GetString("appname");
            //_ = int.TryParse(a, out int id);
            if (!filtersDB.Any())
            {
                var service = new FilterService();
                foreach (var f in service.Read())
                {
                    if (f.AppName == a)
                    {
                        filtersDB.Add(f);
                    }
                }
                //filtersDB.AddRange(service.Read());
            }

            return new JsonResult(filtersDB.ToDataSourceResult(request));
        }
        //public JsonResult OnPostCreate([DataSourceRequest] DataSourceRequest request, FilterViewModel filter)
        //{
            
        //    orders.Add(order);

        //    return new JsonResult(new[] { order }.ToDataSourceResult(request, ModelState));
        //}
    }
}
