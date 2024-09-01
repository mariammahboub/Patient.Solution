using Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Config
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.MRN).IsRequired().HasMaxLength(50);
            builder.Property(p => p.FullName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.MotherName).HasMaxLength(100);
            builder.Property(p => p.TransferFrom).HasMaxLength(100);

            // Relationships
            builder.HasMany(p => p.PatientReservations)
                   .WithOne(r => r.Patient)
                   .HasForeignKey(r => r.PatientId);

            builder.HasMany(p => p.PatientTherapies)
                   .WithOne(t => t.Patient)
                   .HasForeignKey(t => t.PatientId);
        }
    }
}
