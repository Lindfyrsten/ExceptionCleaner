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
    public class DetailsModel : PageModel
    {
        private readonly ScanApp.db.Database.ExContext _context;

        public DetailsModel(ScanApp.db.Database.ExContext context)
        {
            _context = context;
        }

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
    }
}
