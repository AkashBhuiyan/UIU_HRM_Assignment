using Code_First_MemberShip_Provider.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Code_First_MemberShip_Provider.Models
{
    public class Faculty
    {
        [Key, ForeignKey("User")]
        public Guid UserId { get; set; }
        public bool IsDeleted { get; set; }

        
        [DataType(DataType.Text)]
        [StringLength(25, MinimumLength =1)]
        [Required(ErrorMessage = "*** Please give first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [StringLength(25, MinimumLength = 1)]
        [Required(ErrorMessage = "*** Please give last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
       

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "*** Please select gender")]
        public string Gender { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "*** Please select date of birth")]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
      
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "*** Please select designation")]
        public string Designation { get; set; }
       
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "*** Please select department name")]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "*** Please give salary")]
        public double Salary { get; set; }
        public string ImageName { get; set; }
        public string ImageVirtualPath { get; set; }
        public string ImagePhysicalPath { get; set; }

        [NotMapped]
        //[Required(ErrorMessage = "Please Upload File")]
        [Display(Name = "Upload Profile Picture")]
       // [ValidateFile]
        public HttpPostedFileBase file { get; set; }

 
        public User User { get; set; }

        public Faculty()
        {
            this.IsDeleted = false;
        }

    }
}