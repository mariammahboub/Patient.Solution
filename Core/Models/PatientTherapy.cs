using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{

    public class PatientTherapy: BaseEntity
    {
        public int? PatientId { get; set; }
        public int? NumberOfSessions { get; set; }
        public int? CompletedSessions { get; set; }
        public bool? IsNearClose => NumberOfSessions - CompletedSessions <= 1;

        // Navigation properties
        public Patient? Patient { get; set; }
    }
}
