using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Millennium_Rekrutacja.Model;

namespace Millennium_Rekrutacja.Common.DbConenction
{
    public class RekrutacjaDbContext : DbContext
    {
        public RekrutacjaDbContext(DbContextOptions<RekrutacjaDbContext> options) : base(options)
        { }

        public DbSet<Article> Article { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleEntityConfiguration());
        }
    }
}
