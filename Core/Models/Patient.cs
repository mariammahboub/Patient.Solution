using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Patient:BaseEntity
    {
        public string MRN { get; set; } // Mandatory
        public string FullName { get; set; } // Mandatory
        public string? MotherName { get; set; } // Optional
        public string? TransferFrom { get; set; } // Optional
        public DateTime BirthDate { get; set; }

        // Navigation properties
        public ICollection<PatientReservation>? PatientReservations { get; set; }
        public ICollection<PatientTherapy>? PatientTherapies { get; set; }
    }
}
