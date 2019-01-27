using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace The.Machine.Entities
{
    public class TheMachineContext : DbContext
    {
        public TheMachineContext(DbContextOptions<TheMachineContext> options) : base(options)
        {
           if(!Drinks.Any())
           Database.EnsureCreated();
        }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePreference> EmployeePreferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drink>().HasData(new Drink { Id = 1, Name = "Thé", Description = "Pour se concentrer" });
            modelBuilder.Entity<Drink>().HasData(new Drink { Id = 2, Name = "Café",Description = "Pour se reposer" });
            modelBuilder.Entity<Drink>().HasData(new Drink { Id = 3, Name = "Chocolat", Description = "Pour savourer" });
        }
    }
}
