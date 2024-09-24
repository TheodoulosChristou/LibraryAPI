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

        public DbSet<Author> Author { get; set; }

        public DbSet<Publish> Publish { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new PublishConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }
    }
}
