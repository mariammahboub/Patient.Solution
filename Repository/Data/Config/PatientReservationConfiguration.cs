using Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data.Config
{
    public class PatientReservationConfiguration : IEntityTypeConfiguration<PatientReservation>
    {
        public void Configure(EntityTypeBuilder<PatientReservation> builder)
        {
            builder.HasKey(pr => pr.Id);

            builder.Property(pr => pr.InDate).IsRequired();
            builder.Property(pr => pr.CheckoutDate).IsRequired();
            builder.Property(pr => pr.Status)
                   .IsRequired()
                   .HasConversion(
                       v => v.ToString(),
                       v => (ReservationStatus)Enum.Parse(typeof(ReservationStatus), v)
                   );

            // Relationships
            builder.HasOne(pr => pr.Patient)
                   .WithMany(p => p.PatientReservations)
                   .HasForeignKey(pr => pr.PatientId);

            builder.HasOne(pr => pr.Room)
                   .WithMany(r => r.PatientReservations)
                   .HasForeignKey(pr => pr.RoomId);
        }
    }
}
