using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScanApp.db.Model;
using ScanApp.db.Database;

namespace ScanAppWeb.Pages.AppExceptions
{
    public class AppExceptionsModel : PageModel
    {
        private readonly ExContext _context;

        [FromRoute]
        public int Id { get; set; }
        public string AppName { get; set; }
        public AppExceptionsModel(ExContext context)
        {
            _context = context;
            
        }

        public IList<ScanApp.db.Model.Exception> Exceptions { get;set; }

        public void OnGet()
        {
            var test = Id;
            Exceptions = _context.GetExceptionsByAppId(Id);
            AppName = _context.Apps.Where(a => a.AppId == Id).FirstOrDefault().Name;
            
        }
    }
}
