using Microsoft.EntityFrameworkCore;

namespace TechCareerOdev5.Odev_5.Models.ORM {
    public class AppDbContext : DbContext {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Server=DESKTOP-RHMNBG1\\SQLEXPRESS; Database=BootcampOdev5; trusted_connection=true");
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
    }
}
