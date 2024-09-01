using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class PatientReservation:BaseEntity
    {
        public int? PatientId { get; set; }
        public int? RoomId { get; set; }
        public DateTime? InDate { get; set; }
        public DateTime? CheckoutDate { get; set; }
        public ReservationStatus? Status { get; set; } // Paid, Not Paid, Insurance

        // Navigation properties
        public Patient? Patient { get; set; }
        public Room? Room { get; set; }
    }

    public enum ReservationStatus
    {
        Paid,
        NotPaid,
        Insurance
    }
}
