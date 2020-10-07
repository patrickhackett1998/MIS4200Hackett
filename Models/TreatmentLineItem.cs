using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200Hackett.Models
{
    public class TreatmentLineItem
    {
        [Key]
        public int orderdetailID { get; set; }
        public int qtyOrdered { get; set; }
        public decimal price { get; set; }
        public int TreatmentID { get; set; }
        public int PatientID { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Treatment Treatment { get; set; }
    }
}