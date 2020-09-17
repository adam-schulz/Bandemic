using Bandemic.Data;
using Bandemic.Models.TourDate;
using Bandemic.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bandemic.MVC.Controllers
{
    public class TourDateController : Controller
    {
        // GET: TourDate
        public ActionResult Index()
        {
            return View(new TourDateService().GetTourDateList());
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New Tour Date";

            List<Artist> Artists = new ArtistService().GetArtists().ToList();

            var artistQuery = from a in Artists
                        select new SelectListItem()
                        {
                            Value = a.ArtistId.ToString(),
                            Text = a.ArtistName
                        };
            ViewBag.ArtistId = artistQuery.ToList();

            List<Venue> Venues = new VenueService().GetVenues().ToList();

            var venueQuery = from v in Venues
                        select new SelectListItem()
                        {
                            Value = v.VenueId.ToString(),
                            Text = v.VenueName
                        };
            ViewBag.VenueId = venueQuery.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TourDateCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (new TourDateService().CreateTourDate(model))
            {
                TempData["SaveResult"] = "Tour Date was created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "An error occured, unable to create new tour date");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var tourDate = new TourDateService().GetTourDateDetailById(id);
            return View(tourDate);
        }


        public ActionResult Edit(int id)
        {
            var tourDate = new TourDateService().GetTourDateDetailById(id);

            List<Artist> Artists = new ArtistService().GetArtists().ToList();
            ViewBag.ArtistId = Artists.Select(a => new SelectListItem()
            {
                Value = a.ArtistId.ToString(),
                Text = a.ArtistName,
                Selected = tourDate.ArtistId == a.ArtistId
            });

            List<Venue> Venues = new VenueService().GetVenues().ToList();
            ViewBag.VenueId = Venues.Select(v => new SelectListItem()
            {
                Value = v.VenueId.ToString(),
                Text = v.VenueName,
                Selected = tourDate.VenueId == v.VenueId
            });

            return View(new TourDateEdit
            {
                TourDateId = tourDate.TourDateId,
                DateOfShow = tourDate.DateOfShow,
                ArtistId = tourDate.ArtistId,
                VenueId = tourDate.VenueId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TourDateEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TourDateId != id)
            {
                ModelState.AddModelError("", "Id not found.");
                return View(model);
            }

            if (new TourDateService().UpdateTourDate(model))
            {
                TempData["SaveResult"] = "Tour Date updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "An error occured, unable to create new tour date.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateTourDateService();
            var model = svc.GetTourDateDetailById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTourDate(int id)
        {
            var service = CreateTourDateService();

            service.DeleteTourDate(id);

            TempData["SaveResult"] = "Tour Date was removed from database.";

            return RedirectToAction("Index");
        }

        private TourDateService CreateTourDateService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TourDateService(userId);
            return service;
        }
    }
}

