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
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.RoomNumber).IsRequired().HasMaxLength(20);
            builder.Property(r => r.RoomFloor).IsRequired().HasMaxLength(50);

            // Relationships
            builder.HasMany(r => r.PatientReservations)
                   .WithOne(pr => pr.Room)
                   .HasForeignKey(pr => pr.RoomId);
        }
    
    }
}
