using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DevObsDemoRazor.Models;

namespace RazorPagesStudio.Data
{
    public class RazorPagesMovieContext : DbContext
    {

        public RazorPagesMovieContext (DbContextOptions<RazorPagesMovieContext> options)
            : base(options)
        {
        }

        public DbSet<DevObsDemoRazor.Models.Studio> Studio { get; set; } = default!;
    }
   
}
