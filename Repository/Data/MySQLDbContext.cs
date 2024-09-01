using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace Repository.Data
{
    public class MySQLDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<PatientReservation> PatientReservations { get; set; }
        public DbSet<PatientTherapy> PatientTherapies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public MySQLDbContext(DbContextOptions<MySQLDbContext> options) : base(options) { }

    }
}
