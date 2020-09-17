using Bandemic.Models.Venue;
using Bandemic.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bandemic.MVC.Controllers
{
    public class VenueController : Controller
    {
        // GET: Venue
        public ActionResult Index()
        {
            return View(new VenueService().GetVenueList());
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New Venue";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VenueCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (new VenueService().CreateVenue(model))
            {
                TempData["SaveResult"] = "Venue was created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "An error occured, unable to create new venue");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var venue = new VenueService().GetVenueDetailById(id);
            return View(venue);
        }

        public ActionResult Edit(int id)
        {
            var venue = new VenueService().GetVenueDetailById(id);
            return View(new VenueEdit
            {
                VenueId = venue.VenueId,
                VenueName = venue.VenueName,
                VenueAddress = venue.VenueAddress,
                VenueLocation = venue.VenueLocation
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VenueEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.VenueId != id)
            {
                ModelState.AddModelError("", "Id not found.");
                return View(model);
            }

            if (new VenueService().UpdateVenue(model))
            {
                TempData["SaveResult"] = "Venue updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "An error occured, unable to create new venue.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateVenueService();
            var model = svc.GetVenueDetailById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteVenue(int id)
        {
            var service = CreateVenueService();

            service.DeleteVenue(id);

            TempData["SaveResult"] = "Venue was removed from database.";

            return RedirectToAction("Index");
        }

        private VenueService CreateVenueService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VenueService(userId);
            return service;
        }
    }
}