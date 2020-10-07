using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200Hackett.Models
{
    public class Doctor
    {
        public Guid ID { get; set; }
        public int DoctorId { get; set; }

        [Display(Name = "Doctor First Name")]
        [Required(ErrorMessage = "Doctor first name is required")]
        [StringLength(20)]
        public string firstName { get; set; }

        [Display(Name = "Doctor Last Name")]
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
        public DateTime DoctorSince { get; set; }
        public ICollection<Patient> Patient { get; set; }

    }
}