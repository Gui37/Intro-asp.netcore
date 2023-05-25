using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASPIntro.Models;

namespace ASPIntro.Data
{
    public class ASPIntroContext : DbContext
    {
        public ASPIntroContext (DbContextOptions<ASPIntroContext> options)
            : base(options)
        {
        }

        public DbSet<ASPIntro.Models.Filme> Filme { get; set; } = default!;
    }
}
