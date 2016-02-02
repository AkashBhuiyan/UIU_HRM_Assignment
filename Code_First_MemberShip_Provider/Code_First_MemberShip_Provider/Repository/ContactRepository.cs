using Code_First_MemberShip_Provider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code_First_MemberShip_Provider.Repository
{
    public class ContactRepository
    {
        private DataContext db = new DataContext();
        public ContactRepository()
        {
            this.db = new DataContext();
        }

        public void CreatContact(ContactInformation contactInformation)
        {
            db.ContactInformations.Add(contactInformation);
            db.SaveChanges();
        }

        public void CreatFaculty(Faculty faculty)
        {
            db.Faculties.Add(faculty);
            db.SaveChanges();
        }

        public void CreatEducation(EducationalInformation educationalInformation)
        {
            db.EducationalInformations.Add(educationalInformation);
            db.SaveChanges();
        }

    }
}