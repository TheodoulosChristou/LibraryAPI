using Microsoft.EntityFrameworkCore;

namespace LIbraryAPI.DataContext
{
    public class ProjectDbContext:DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options):base(options)
        {
            
        }
    }
}
