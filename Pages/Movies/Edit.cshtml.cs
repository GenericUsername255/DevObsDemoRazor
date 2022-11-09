using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevObsDemoRazor.Models;
using RazorPagesStudio.Data;

namespace DevObsDemoRazor.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesStudio.Data.RazorPagesMovieContext _context;

        public EditModel(RazorPagesStudio.Data.RazorPagesMovieContext context)
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

            var studio =  await _context.Studio.FirstOrDefaultAsync(m => m.Id == id);
            if (studio == null)
            {
                return NotFound();
            }
            Studio = studio;
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

            _context.Attach(Studio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudioExists(Studio.Id))
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

        private bool StudioExists(int id)
        {
          return (_context.Studio?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
