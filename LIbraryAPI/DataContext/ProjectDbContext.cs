using LIbraryAPI.Configurations;
using LIbraryAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace LIbraryAPI.DataContext
{
    public class ProjectDbContext:DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options):base(options)
        {
            
        }

        public DbSet<Book> Book {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
        }
    }
}
