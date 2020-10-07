using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace MIS4200Hackett.Models
{
    public class customer
    {
        public Guid ID { get; set; }


        internal string fullName;

        public int customerId { get; set; }

        [Display(Name = "Customer First Name")]
        [Required(ErrorMessage = "Customer first name is required")]
        [StringLength(20)]

        public string firstName { get; set; }

        [Display(Name = "Customer Last Name")]
        [Required]
        [StringLength(20)]
        public string lastName { get; set; }

        [Display(Name = "Most used email address")]
        [Required]
        [EmailAddress(ErrorMessage = "Enter your most frequently used email address")]
        public string email { get; set; }
        [Display(Name = "Mobile phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\(/d{3}-)\d{3}-\d{4}$",
            ErrorMessage = "Phone numbers must be in the format (xxx) xxx-xxxx or xxx-xxx-xxxx")]
        public string phone { get; set; }

        [Display(Name = "Date Joined")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime customerSince { get; set; }
        public ICollection<order> order { get; set; }









    }
}