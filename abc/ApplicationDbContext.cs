using abc.Entities;
using Microsoft.EntityFrameworkCore;

namespace abc
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        public DbSet<Screening> screenings { get; set; }
        public DbSet<Movie> movies { get; set; }
    }
}
