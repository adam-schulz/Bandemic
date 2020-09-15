using Bandemic.Models.TourDate;
using Bandemic.Services;
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
    }
}