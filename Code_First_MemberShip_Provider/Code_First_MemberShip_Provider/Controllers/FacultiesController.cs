using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Code_First_MemberShip_Provider.Models;
using CodeFirstMembership.Repository;
using System.IO;

namespace Code_First_MemberShip_Provider.Controllers
{
    [Authorize(Roles = "User")]
    public class FacultiesController : Controller
    {
        private DataContext db = new DataContext();
        [HttpGet]
        public ActionResult Details(Guid? id)
        {
            id = new UserRepository().FindUserIdByEmail(User.Identity.Name);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty faculty = db.Faculties.Find(id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            return View(faculty);
        }

       [HttpGet]
        public ActionResult Edit(Guid? id)
        {
            id = new UserRepository().FindUserIdByEmail(User.Identity.Name);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty faculty = db.Faculties.Find(id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new UserRepository().FindUserIdByEmail(User.Identity.Name);
            return View(faculty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,IsDeleted,FirstName,LastName,Gender,DateOfBirth,Designation,DepartmentName,Salary,ImageName,ImageVirtualPath,ImagePhysicalPath,file")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                if (faculty.file != null)
                {
                    if (!(faculty.file.ContentType == "image/jpeg" || faculty.file.ContentType == "image/gif" || faculty.file.ContentType == "image/png"))
                    {
                        ModelState.AddModelError("", "File type allowed : jpeg ,gif or png ");
                        return View(faculty);
                    }
                    if (faculty.file.ContentLength > (2 * 1024 * 1024))
                    {
                        ModelState.AddModelError("", "File size must be less than 2 MB");
                        return View(faculty);
                    }

                    faculty.ImageName = Path.GetFileNameWithoutExtension(faculty.file.FileName) + faculty.UserId + Path.GetExtension(faculty.file.FileName);
                    faculty.ImagePhysicalPath = Path.Combine(Server.MapPath("~/UploadedProfilesPictures"), faculty.ImageName);
                    faculty.ImageVirtualPath = @"~/UploadedProfilesPictures/" + faculty.ImageName;
                    faculty.file.SaveAs(Server.MapPath(faculty.ImageVirtualPath));
                    db.Entry(faculty).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Details");
                }
                if (faculty.file == null)
                { 
                    db.Entry(faculty).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Details");
                }
                

            }
            ViewBag.UserId = new UserRepository().FindUserIdByEmail(User.Identity.Name);
            return View(faculty);
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
