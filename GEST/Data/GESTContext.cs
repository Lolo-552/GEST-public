using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GEST.Models;

namespace GEST.Data
{
    public class GESTContext : DbContext
    {
        public GESTContext (DbContextOptions<GESTContext> options)
            : base(options)
        {
        }

        public DbSet<GEST.Models.Projects> Projects { get; set; } = default!;
        public DbSet<GEST.Models.News> News { get; set; }
        public DbSet<GEST.Models.Management> Management { get; set; }
        public DbSet<GEST.Models.Achievements> Achievements { get; set; }
        public DbSet<GEST.Models.Publications> Publications { get; set; }
        public DbSet<GEST.Areas.Admin.Models.Admin> Admin { get; set; }
        public DbSet<GEST.Models.Photos> Photos { get; set; }
        public DbSet<GEST.Models.Files> Files { get; set; }
        public DbSet<GEST.Models.HomePage> HomePage { get; set; }
        public DbSet<GEST.Models.Pages> Pages { get; set; }

    }
}
