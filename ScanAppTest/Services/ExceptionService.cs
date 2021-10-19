using ScanApp.db.Database;
using ScanAppWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScanApp.Web.Services
{
    public class ExceptionService
    {
        public IEnumerable<ExViewModel> Read()
        {
            return GetAll();
        }

        public IList<ExViewModel> GetAll()
        {
            using (var db = new ExContext())
            {

                var result = db.Exceptions.ToList().Select(ex =>
                {
                    return new ExViewModel
                    {
                        ExceptionId = ex.ExceptionId,
                        AppId = ex.AppId,
                        FileName = ex.FileName,
                        ExMsg = ex.ExMsg,
                        AppName = db.Apps.Where(a => a.AppId == ex.AppId).FirstOrDefault().Name
                    };
                }).ToList();


                return result;
            }
        }
    }
}
