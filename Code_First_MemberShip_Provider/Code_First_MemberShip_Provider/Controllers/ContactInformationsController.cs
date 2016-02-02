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

namespace Code_First_MemberShip_Provider.Controllers
{
    [Authorize(Roles = "User")]
    public class ContactInformationsController : Controller
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
            ContactInformation contactInformation = db.ContactInformations.Find(id);
            if (contactInformation == null)
            {
                return HttpNotFound();
            }
            return View(contactInformation);
        }

        [HttpGet]
        public ActionResult Edit(Guid? id)
        {
            id = new UserRepository().FindUserIdByEmail(User.Identity.Name);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInformation contactInformation = db.ContactInformations.Find(id);
            if (contactInformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new UserRepository().FindUserIdByEmail(User.Identity.Name);
            return View(contactInformation);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Email,PhoneNumber,TelePhonNumber,BloodGroup,Address")] ContactInformation contactInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            ViewBag.UserId = new UserRepository().FindUserIdByEmail(User.Identity.Name);
            return View(contactInformation);
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
