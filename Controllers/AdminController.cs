﻿using GuitarApp.DataAccess;
using GuitarApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuitarApp.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationUserManager _userManager;
        private ArtistRepository _artistRepository;
        private SongRepository _songRepository;

        public AdminController()
        {
        }

        public AdminController(ApplicationUserManager userManager, ArtistRepository artistRepository, SongRepository songRepository)
        {
            UserManager = userManager;
            ArtistRepository = artistRepository;
            SongRepository = songRepository;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ArtistRepository ArtistRepository
        {
            get
            {
                return _artistRepository ?? new ArtistRepository(HttpContext.GetOwinContext().Get<ApplicationDbContext>());
            }
            private set
            {
                _artistRepository = value;
            }
        }
        public SongRepository SongRepository
        {
            get
            {
                return _songRepository ?? new SongRepository(HttpContext.GetOwinContext().Get<ApplicationDbContext>());
            }
            private set
            {
                _songRepository = value;
            }
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users(string contains)
        {
            IQueryable<ApplicationUser> users = String.IsNullOrEmpty(contains) ?
                UserManager.Users :
                UserManager.Users.Where(u => u.UserName.Contains(contains));

            var model = new BrowseUsersViewModel() { Users = users.ToList() };

            return View(model);
        }

        public ActionResult Artists(string nameSubstring)
        {
            IList<Artist> artists = String.IsNullOrEmpty(nameSubstring) ?
                ArtistRepository.Get().ToList() :
                ArtistRepository.LookupByName(nameSubstring).ToList();

            var model = new BrowseArtistsViewModel() { Artists = artists };

            return View(model);
        }

        public ActionResult Songs(string songSubstring)
        {
            IList<Song> songs = String.IsNullOrEmpty(songSubstring) ?
                SongRepository.Get().ToList() :
                SongRepository.LookupByName(songSubstring).ToList();

            var model = new BrowseSongsViewModel() { Songs = songs };

            return View(model);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_artistRepository != null)
                {
                    _artistRepository.Dispose();
                    _artistRepository = null;
                }

                if (_songRepository != null)
                {
                    _songRepository.Dispose();
                    _songRepository = null;
                }
            }

            base.Dispose(disposing);
        }
    }
}