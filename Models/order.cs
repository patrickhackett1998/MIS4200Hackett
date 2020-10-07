using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace MIS4200Hackett.Models
{
    public class order
    {
        public int orderID { get; set; }

        public string description { get; set; }

        public DateTime orderDate { get; set; }

        public int customerID { get; set; }
        public virtual customer customer { get; set; }
        public ICollection<LineItem> LineItem { get; set; }

        public string orderDescription
        {
            get


            {
                return "Order by " + customer.fullName + ". Description: " + description;
            }
        }

    }
}