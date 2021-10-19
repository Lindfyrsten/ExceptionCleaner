using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScanApp.db.Database;
using ScanApp.db.Model;

namespace ScanApp.Web.Pages.AppFilters
{
    public class DeleteModel : PageModel
    {
        private readonly ScanApp.db.Database.ExContext _context;

        public DeleteModel(ScanApp.db.Database.ExContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Filter Filter { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Filter = await _context.Filters.FirstOrDefaultAsync(m => m.FilterId == id);

            if (Filter == null)
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

            Filter = await _context.Filters.FindAsync(id);

            if (Filter != null)
            {
                _context.Filters.Remove(Filter);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
