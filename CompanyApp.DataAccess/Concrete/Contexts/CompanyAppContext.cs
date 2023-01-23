using CompanyApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyApp.DataAccess.Concrete.Contexts
{
    public class CompanyAppContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connStr = "Server=localhost,1433;Database=CompanyDB;User Id=sa;Password=Password123;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connStr, opt =>
            {
                //opt.EnableRetryOnFailure();
            });
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Tech> Techs { get; set; }
        public DbSet<EmployeeTech> EmployeeTechs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(a =>
            {
                a.ToTable("Employees").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.FirstName).HasColumnName("FirstName");
                a.Property(p => p.LastName).HasColumnName("LastName");
                a.Property(p => p.Age).HasColumnName("Age");
                a.Property(p => p.Salary).HasColumnName("Salary");
                a.HasOne(p => p.Project);
            });

            modelBuilder.Entity<Project>(a =>
            {
                a.ToTable("Projects").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.ProjectName).HasColumnName("ProjectName");
                a.HasMany(P => P.Employees);
            });

            modelBuilder.Entity<Tech>(a =>
            {
                a.ToTable("Techs").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.TechName).HasColumnName("TechName");
            });

            //modelBuilder.Entity<EmployeeTech>(a =>
            //{
            //    a.ToTable("EmployeeTechs").HasKey(et => new { et.EmployeeId, et.TechId });
            //    a.HasOne(p => p.Employee)
            //    .WithMany(p => p.EmployeeTechs)
            //    .HasForeignKey(p => p.EmployeeId);

            //    a.HasOne(p => p.Tech)
            //   .WithMany(p => p.EmployeeTechs)
            //   .HasForeignKey(p => p.TechId);
            //});

        }

    }
}
