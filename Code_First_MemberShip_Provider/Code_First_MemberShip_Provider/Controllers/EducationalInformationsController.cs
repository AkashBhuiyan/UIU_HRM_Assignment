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
    public class EducationalInformationsController : Controller
    {
        private DataContext db = new DataContext(); 
        public ActionResult Details(Guid? id)
        {
            id = new UserRepository().FindUserIdByEmail(User.Identity.Name);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationalInformation educationalInformation = db.EducationalInformations.Find(id);
            if (educationalInformation == null)
            {
                return HttpNotFound();
            }
            return View(educationalInformation);
        }

        public ActionResult Edit(Guid? id)
        {
            id = new UserRepository().FindUserIdByEmail(User.Identity.Name);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationalInformation educationalInformation = db.EducationalInformations.Find(id);
            if (educationalInformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new UserRepository().FindUserIdByEmail(User.Identity.Name);
            return View(educationalInformation);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,CertificateImageName,CertificateVirtualPath,CertificatePhysicalPath,CertificateImageFile,OptionalCertificateImageName,OptionalCertificateVirtualPath,OptionalCertificatePhysicalPath,OptionalCertificateImageFile")] EducationalInformation educationalInformation)
        {
            if (ModelState.IsValid)
            {
                if (educationalInformation.CertificateImageFile != null)
                {
                    if (!(educationalInformation.CertificateImageFile.ContentType == "image/jpeg" || educationalInformation.CertificateImageFile.ContentType == "image/gif" || educationalInformation.CertificateImageFile.ContentType == "image/png"))
                    {
                        ModelState.AddModelError("", "File type allowed : jpeg ,gif or png ");
                        return View(educationalInformation);
                    }
                    if (educationalInformation.CertificateImageFile.ContentLength > (5 * 1024 * 1024))
                    {
                        ModelState.AddModelError("", "File size must be less than 5 MB");
                        return View(educationalInformation);
                    }

                    educationalInformation.CertificateImageName = Path.GetFileNameWithoutExtension(educationalInformation.CertificateImageFile.FileName) + educationalInformation.UserId + Path.GetExtension(educationalInformation.CertificateImageFile.FileName);
                    educationalInformation.CertificatePhysicalPath = Path.Combine(Server.MapPath("~/UploadedEducationFiles"), educationalInformation.CertificateImageName);
                    educationalInformation.CertificateVirtualPath = @"~/UploadedEducationFiles/" + educationalInformation.CertificateImageName;
                    educationalInformation.CertificateImageFile.SaveAs(Server.MapPath(educationalInformation.CertificateVirtualPath));
                }
                if (educationalInformation.OptionalCertificateImageFile != null)
                {
                    if (!(educationalInformation.OptionalCertificateImageFile.ContentType == "image/jpeg" || educationalInformation.OptionalCertificateImageFile.ContentType == "image/gif" || educationalInformation.OptionalCertificateImageFile.ContentType == "image/png"))
                    {
                        ModelState.AddModelError("", "File type allowed : jpeg ,gif or png ");
                        return View(educationalInformation);
                    }
                    if (educationalInformation.OptionalCertificateImageFile.ContentLength > (5 * 1024 * 1024))
                    {
                        ModelState.AddModelError("", "File size must be less than 5 MB");
                        return View(educationalInformation);
                    }

                    educationalInformation.OptionalCertificateImageName = Path.GetFileNameWithoutExtension(educationalInformation.OptionalCertificateImageFile.FileName) + educationalInformation.UserId + Path.GetExtension(educationalInformation.OptionalCertificateImageFile.FileName);
                    educationalInformation.OptionalCertificatePhysicalPath = Path.Combine(Server.MapPath("~/UploadedEducationFiles"), educationalInformation.OptionalCertificateImageName);
                    educationalInformation.OptionalCertificateVirtualPath = @"~/UploadedEducationFiles/" + educationalInformation.CertificateImageName;
                    educationalInformation.OptionalCertificateImageFile.SaveAs(Server.MapPath(educationalInformation.OptionalCertificateVirtualPath));
                       
                }
                db.Entry(educationalInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");

            }
            ViewBag.UserId = new UserRepository().FindUserIdByEmail(User.Identity.Name);
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
