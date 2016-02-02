using Code_First_MemberShip_Provider.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Code_First_MemberShip_Provider.Models
{
    public class EducationalInformation
    {
        [Key, ForeignKey("User")]
        public Guid UserId { get; set; }
        public string CertificateImageName { get; set; }
        public string CertificateVirtualPath { get; set; }
        public string CertificatePhysicalPath { get; set; }

        [NotMapped]
        [Display(Name = "Upload Profile Picture")]
        public HttpPostedFileBase CertificateImageFile { get; set; }

        public string OptionalCertificateImageName { get; set; }
        public string OptionalCertificateVirtualPath { get; set; }
        public string OptionalCertificatePhysicalPath { get; set; }

        [NotMapped]
        [Display(Name = "Upload Profile Picture")]
        public HttpPostedFileBase OptionalCertificateImageFile { get; set; }


        public User User { get; set; }



    }
}