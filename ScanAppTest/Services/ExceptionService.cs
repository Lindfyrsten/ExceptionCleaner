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

        public IEnumerable<ExViewModel> ReadByAppId(int appid)
        {
            return GetById(appid);
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
                        Date = ex.Date.ToShortDateString(),
                        AppName = db.Apps.Where(a => a.AppId == ex.AppId).FirstOrDefault().Name
                    };
                }).ToList();


                return result;
            }
        }

        public IList<ExViewModel> GetById(int appid)
        {
            using (var db = new ExContext())
            {
                var result = db.GetExceptionsByAppId(appid).Select(ex =>
                {
                    return new ExViewModel
                    {
                        ExceptionId = ex.ExceptionId,
                        AppId = ex.AppId,
                        FileName = ex.FileName,
                        ExMsg = ex.ExMsg,
                        Date = ex.Date.ToShortDateString(),
                        AppName = db.Apps.Where(a => a.AppId == ex.AppId).FirstOrDefault().Name
                    };
                }).ToList();


                return result;
            }
        }
    }
}
