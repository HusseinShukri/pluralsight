using Microsoft.EntityFrameworkCore;
using PatientRegistrySystem.Domain.Entities;

namespace PatientRegistrySystem.Data
{
    public class PatientContext : DbContext
    {
        public PatientContext()
        {
        }
        public PatientContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Record> Record { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region FluintApi
            modelBuilder.Entity<Employee>()
               .HasOne(e => e.User)
               .WithMany(u => u.Employee).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Doctor>()
                        .HasMany(a => a.Record)
                        .WithOne(u => u.Doctor).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Employee).WithOne(e => e.User).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                        .HasMany(e => e.Record).WithOne(e => e.User).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<UserRole>().HasOne(u => u.User).WithMany(ur => ur.UserRole).HasForeignKey(u => u.UserId);
            modelBuilder.Entity<UserRole>().HasOne(r => r.Role).WithMany(ur => ur.UserRole).HasForeignKey(r => r.RoleId);

            #endregion
            #region Seeds
            modelBuilder.Seed();
            #endregion
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-0CVKC97;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; Initial Catalog = PatientRegistrySystem");
        }
    }
}
