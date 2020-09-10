using Bandemic.Models;
using Bandemic.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bandemic.MVC.Controllers
{
    public class ArtistController : Controller
    {
        // GET: Artist
        public ActionResult Index()
        {
            return View(CreateArtistService().GetArtistList());
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New Artist";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtistCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateArtistService().CreateArtist(model))
            {
                TempData["SaveResult"] = "Artist was created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "An error occured, unable to create new artist");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var artist = CreateArtistService().GetArtistDetailById(id);
            return View(artist);
        }

        public ActionResult Edit(int id)
        {
            var artist = CreateArtistService().GetArtistDetailById(id);
            return View(new ArtistEdit
            {
                ArtistId = artist.ArtistId,
                ArtistName = artist.ArtistName
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArtistEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ArtistId != id)
            {
                ModelState.AddModelError("", "Id not found.");
                return View(model);
            }

            if (CreateArtistService().UpdateArtist(model))
            {
                TempData["SaveResult"] = "Artist updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "An error occured, unable to create new artist.");
            return View(model);
        }

        private ArtistService CreateArtistService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtistService(userId);
            return service;
               
        }
    }
}