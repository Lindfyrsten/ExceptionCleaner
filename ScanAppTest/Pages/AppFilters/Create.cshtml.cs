using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScanApp.db.Database;
using ScanApp.db.Model;

namespace ScanApp.Web.Pages.AppFilters
{
    public class CreateModel : PageModel
    {
        private readonly ScanApp.db.Database.ExContext _context;

        public CreateModel(ScanApp.db.Database.ExContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Filter Filter { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Filters.Add(Filter);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
