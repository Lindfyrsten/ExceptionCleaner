using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScanApp.db.Database;
using ScanApp.db.Model;

namespace ScanApp.Web.Pages.AppFilters
{
    public class EditModel : PageModel
    {
        private readonly ScanApp.db.Database.ExContext _context;

        public EditModel(ScanApp.db.Database.ExContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Filter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilterExists(Filter.FilterId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FilterExists(int id)
        {
            return _context.Filters.Any(e => e.FilterId == id);
        }
    }
}
