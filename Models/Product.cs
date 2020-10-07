using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS4200Hackett.Models
{
    public class Product
    {
        public int productID { get; set; }
        public string description { get; set; }
        public decimal unitCost { get; set; }

        public int supplierID { get; set; }
        public ICollection<LineItem> LineItem { get; set; }

    }
}