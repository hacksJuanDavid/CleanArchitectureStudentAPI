using Microsoft.EntityFrameworkCore;
using Student.Domain.Entities;

namespace Student.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {   
        // AppDbContext Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        
        // Add DbSets here
        public DbSet<StudentEntity> Students { get; set; }

    }
}
