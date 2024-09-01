using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Room: BaseEntity
    {
        public string RoomNumber { get; set; } // Mandatory
        public string RoomFloor { get; set; } // Mandatory

        // Navigation properties
        public ICollection<PatientReservation>? PatientReservations { get; set; }
    }
}
