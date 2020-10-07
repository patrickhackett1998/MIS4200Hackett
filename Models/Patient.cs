using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS4200Hackett.Models
{
    public class Patient
    {
        public int PatientID { get; set; }

        public string description { get; set; }

        public DateTime PatientDate { get; set; }

        public int DoctorID { get; set; }
        public virtual Doctor Doctor { get; set; }
        public ICollection<TreatmentLineItem> TreatmentLineItem { get; set; }
    }
}