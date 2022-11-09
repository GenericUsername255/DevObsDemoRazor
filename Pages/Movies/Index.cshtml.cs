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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesStudio.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesStudio.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Studio> Studio { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Studio != null)
            {
                Studio = await _context.Studio.ToListAsync();
            }
        }
    }
}
