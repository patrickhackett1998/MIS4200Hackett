using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS4200Hackett.Models
{
    public class Treatment
    {
        public int TreatmentID { get; set; }
        public string description { get; set; }
        public decimal unitCost { get; set; }
        public ICollection<TreatmentLineItem> TreatmentLineItem { get; set; }
    }
}