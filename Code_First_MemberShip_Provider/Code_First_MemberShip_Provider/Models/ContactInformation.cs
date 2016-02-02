using Code_First_MemberShip_Provider.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Code_First_MemberShip_Provider.Models
{
    public class ContactInformation
    {
        [Key, ForeignKey("User")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "*** Please input  valid email address")]
        [Display(Name = "Email Address")]
        [Email]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "*** Please give phone number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telephone Number")]
        public string TelePhonNumber { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "*** Please select blood group")]
        [Display(Name = "Blood Group")]
        public string BloodGroup { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "*** Please give address")]
        public string Address { get; set; }
        public User User { get; set; }

    }
}