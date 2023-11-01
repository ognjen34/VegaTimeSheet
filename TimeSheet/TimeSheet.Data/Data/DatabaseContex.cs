using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Data.Models;


namespace TimeSheet.Data.Data
{
    public class DatabaseContex : DbContext
    {
        public DatabaseContex(DbContextOptions<DatabaseContex> options) : base(options)
        {
        }

        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<WorkHourEntity> WorkHours { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }

        public DbSet<CountryEntity> Countries { get; set; }


    }
}
