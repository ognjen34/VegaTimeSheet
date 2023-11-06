using Microsoft.EntityFrameworkCore;
using TimeSheet.Data.Models;


namespace TimeSheet.Data.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<WorkHourEntity> WorkHours { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }

        public DbSet<CountryEntity> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientEntity>()
                .HasOne(c => c.Country)
                .WithMany()  
                .HasForeignKey(c => c.CountryId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }


    }
}
