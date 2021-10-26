using Microsoft.AspNetCore.Http;
using ScanAppWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScanApp.db.Database;
using Microsoft.EntityFrameworkCore;

namespace ScanApp.Web.Services
{
    public class AppService
    {

        public IEnumerable<AppViewModel> Read()
        {
            return GetAll();
        }

        public IList<AppViewModel> GetAll()
        {
            using (var db = new ExContext())
            {
                var result = db.Apps.ToList().Select(app =>
                {
                    return new AppViewModel
                    {
                        AppId = app.AppId,
                        Name = app.Name,
                        AppExceptions = db.GetExceptionsByAppId(app.AppId).Count,
                        FilterCount = db.Filters.Where(f => f.AppName == app.Name).Count()
                            
                    };
                }).ToList();
                return result;
            }
        }
    }
}
