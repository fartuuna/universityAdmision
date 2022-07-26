using Microsoft.EntityFrameworkCore;
using UniversityAdmisionApplcation.Models;

namespace UniversityAdmisionApplcation.Database
{
    public class ApplicationDbContex : DbContext
    {

        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options)
           : base(options)
        {
        }

        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Faculty> faculties { get; set; }
        public DbSet<AdmisionOficer> admisionOficers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registration>().ToTable("Registration");
            modelBuilder.Entity<Faculty>().ToTable("Faculty");
            modelBuilder.Entity<AdmisionOficer>().ToTable("AddmissionOficer");


        }
    }
}