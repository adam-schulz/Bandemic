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

        private ArtistService CreateArtistService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtistService(userId);
            return service;
               
        }
    }
}