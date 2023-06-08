using Microsoft.EntityFrameworkCore;

namespace IP_Final.Models.Domain
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opts) : base(opts)
        {
            
        }

        public DbSet<Software> Softwares { get; set; }

        public DbSet<DenemeTable> DenemeTables { get; set;}

        //public DbSet<Category> Categories { get; set; }

        //public DbSet<ApplicationCategory> ApplicationCategories { get; set; }

        //public DbSet<OperatingSystem> OperatingSystems { get; set; }

        //public DbSet<OperatingSystemApplication> OperatingSystemApplications { get; set; }

        //public DbSet<Language> Languages { get; set; }
    }
}
