using Microsoft.EntityFrameworkCore;
using AppControlDeEmpleados.Models;

namespace AppControlDeEmpleados
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Position> Position { get; set; }

        public DbSet<Role> Role { get; set; }
        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
            .HasOne(e => e.Position)
            .WithMany(p => p.Employees)
            .HasForeignKey(e => e.IdPosition);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Role)
                .WithMany(r => r.Employees)
                .HasForeignKey(e => e.IdRole);
        }
    }
}
