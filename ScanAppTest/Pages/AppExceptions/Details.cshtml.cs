using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScanApp.db.Database;

namespace ScanAppWeb.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ExContext _context;

        public DetailsModel(ExContext context)
        {
            _context = context;
        }

        public ScanApp.db.Model.Exception Exception { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Exceptions = await _context.GetExceptionsAsync();
            Exception = Exceptions.FirstOrDefault(m => m.ExceptionId == id);
            //Exception = await _context.Exceptions.FirstOrDefaultAsync(m => m.ExceptionId == id);

            if (Exception == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
