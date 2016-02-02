using Code_First_MemberShip_Provider.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Code_First_MemberShip_Provider.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminPanelController : Controller
    {
        private DataContext db = new DataContext();

       
        [HttpGet]
        public ActionResult GetAllFacultyBasicDetails(int? page)
        {
            var faculties = db.Faculties.Include(x => x.User);
            return View(faculties.ToList().ToPagedList(page ?? 1,2));
        }

        [HttpGet]
        public ActionResult GetFacultyBasicDetails(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty faculty = db.Faculties.Find(id);
            faculty.User = db.Users.Find(id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            return View(faculty);
        }

        [HttpGet]
        public ActionResult EditFacultyBasicInfo(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty faculty = db.Faculties.Find(id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = faculty.UserId;
            return View(faculty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFacultyBasicInfo([Bind(Include = "UserId,IsDeleted,FirstName,LastName,Gender,DateOfBirth,Designation,DepartmentName,Salary,ImageName,ImageVirtualPath,ImagePhysicalPath,file")] Faculty faculty)
        {

            if (ModelState.IsValid)
            {
                db.Entry(faculty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetAllFacultyBasicDetails");
            }
            ViewBag.UserId = faculty.UserId;
            return View(faculty);

        }
        [HttpGet]
        public ActionResult GetAllFacultyContactInfo(int? page)
        {
            var contactInformations = db.ContactInformations.Include(x=> x.User);
            return View(contactInformations.ToList().ToPagedList(page??1,2));
        }

        [HttpGet]
        public ActionResult GetFacultyContactDetails(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInformation contactInformation = db.ContactInformations.Find(id);
            contactInformation.User= db.Users.Find(id);
            if (contactInformation == null)
            {
                return HttpNotFound();
            }
            return View(contactInformation);
        }

        [HttpGet]
        public ActionResult GetAllFacultyEduInfo(int? page)
        {
            var educationalInformations = db.EducationalInformations.Include(e => e.User);
            return View(educationalInformations.ToList().ToPagedList(page??1,2));
        }

        public ActionResult GetFacultyEducationDetails(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationalInformation educationalInformation = db.EducationalInformations.Find(id);
            educationalInformation.User = db.Users.Find(id);
            if (educationalInformation == null)
            {
                return HttpNotFound();
            }
            return View(educationalInformation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}