using Microsoft.EntityFrameworkCore;

namespace TechCareerWebApiTutorial.Models.ORM {
    public class TechCareerDbContext : DbContext {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Server=DESKTOP-RHMNBG1\\SQLEXPRESS; Database=TechCareerDb; trusted_connection=true");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}

