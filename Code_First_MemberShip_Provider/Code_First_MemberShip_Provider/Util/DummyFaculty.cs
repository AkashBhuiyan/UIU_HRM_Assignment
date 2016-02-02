using Code_First_MemberShip_Provider.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Code_First_MemberShip_Provider.Util
{
    public class DummyFaculty
    {
        public Faculty GetDummyFaculty(Guid id)
        {
            Faculty faculty = new Faculty();
            faculty.UserId =id;
            faculty.DateOfBirth = DateTime.Now;
            faculty.Salary = 111111;
            faculty.FirstName = "UIU";
            faculty.LastName = "UIU";
            faculty.Gender = "UIU";
            faculty.Designation = "UIU";
            faculty.DepartmentName = "UIU";
            faculty.file = null;
            faculty.ImageName = "UIU";
            faculty.ImagePhysicalPath = "UIU";
            faculty.ImageVirtualPath = "~/UploadedProfilesPictures/DefaultProfilePicture.jpg";
            faculty.IsDeleted = false;
            return faculty;
        }
        public ContactInformation GetDummyContact( Guid id)
        {
            ContactInformation _contactInformation = new ContactInformation();
            _contactInformation.UserId = id;
            _contactInformation.Email = "UIU@gmail.com";
            _contactInformation.PhoneNumber = "023013812";
            _contactInformation.TelePhonNumber = "21312983";
            _contactInformation.BloodGroup = "AB";
            _contactInformation.Address = "dsffsdf";
            return _contactInformation;

        }

        public EducationalInformation GetDummyEducatino(Guid id)
        {
            EducationalInformation _educationalInformation = new EducationalInformation();

            _educationalInformation.UserId = id;

            _educationalInformation.CertificateImageName = "Certificate";
            _educationalInformation.CertificatePhysicalPath = "Certificate";
            _educationalInformation.CertificateVirtualPath = "~/UploadedEducationFiles/DefaultCertificate.png";
            _educationalInformation.CertificateImageFile =null;

            _educationalInformation.OptionalCertificateImageName = "Optional";
            _educationalInformation.OptionalCertificatePhysicalPath ="Optional";
            _educationalInformation.OptionalCertificateVirtualPath = "~/UploadedEducationFiles/DefaultCertificate.png";
            _educationalInformation.OptionalCertificateImageFile = null;

            return _educationalInformation;
        }



    }
}