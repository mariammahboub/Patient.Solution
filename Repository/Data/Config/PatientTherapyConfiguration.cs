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
    public class PatientTherapyConfiguration : IEntityTypeConfiguration<PatientTherapy>
    {
        public void Configure(EntityTypeBuilder<PatientTherapy> builder)
        {
            builder.HasKey(pt => pt.Id);
            builder.Property(pt => pt.NumberOfSessions).IsRequired();
            builder.Property(pt => pt.CompletedSessions).IsRequired();

            // Relationships
            builder.HasOne(pt => pt.Patient)
                   .WithMany(p => p.PatientTherapies)
                   .HasForeignKey(pt => pt.PatientId);
        }
    }
}
