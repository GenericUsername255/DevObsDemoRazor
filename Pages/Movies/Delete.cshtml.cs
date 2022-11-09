using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DevObsDemoRazor.Models;
using RazorPagesStudio.Data;

namespace DevObsDemoRazor.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesStudio.Data.RazorPagesMovieContext _context;

        public DeleteModel(RazorPagesStudio.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Studio Studio { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Studio == null)
            {
                return NotFound();
            }

            var studio = await _context.Studio.FirstOrDefaultAsync(m => m.Id == id);

            if (studio == null)
            {
                return NotFound();
            }
            else 
            {
                Studio = studio;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Studio == null)
            {
                return NotFound();
            }
            var studio = await _context.Studio.FindAsync(id);

            if (studio != null)
            {
                Studio = studio;
                _context.Studio.Remove(Studio);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
