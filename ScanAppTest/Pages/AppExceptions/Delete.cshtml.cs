using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScanApp.db.Database;
using ScanApp.db.Model;

namespace ScanAppWeb.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ExContext _context;

        public DeleteModel(ExContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ScanApp.db.Model.Exception Exception { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            // TO DO - fix
            var exceptions = await _context.GetExceptionsAsync();

            Exception = exceptions.FirstOrDefault(m => m.ExceptionId == id);
            //Exception = await _context.Exceptions.FirstOrDefaultAsync(m => m.ExceptionId == id);

            if (Exception == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Exception = await _context.Exceptions.FindAsync(id);

            if (Exception != null)
            {
                _context.Exceptions.Remove(Exception);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { id = Exception.AppId});
        }
    }
}
