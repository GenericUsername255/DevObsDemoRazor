using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DevObsDemoRazor.Models;
using RazorPagesStudio.Data;

namespace DevObsDemoRazor.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesStudio.Data.RazorPagesMovieContext _context;

        public CreateModel(RazorPagesStudio.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Studio Studio { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Studio == null || Studio == null)
            {
                return Page();
            }

            _context.Studio.Add(Studio);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
