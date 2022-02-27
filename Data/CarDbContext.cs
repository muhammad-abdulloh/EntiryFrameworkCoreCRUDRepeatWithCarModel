using Microsoft.EntityFrameworkCore;

namespace RepeatGenericCrud 
{
    internal class CarDbContext : DbContext
    {
        public DbSet<Car> Cars {get; set;}
        public DbSet<Person> People {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDb;Database=CarsDb;Trusted_Connection=True");
        }
    }
}