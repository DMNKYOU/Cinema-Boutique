using Cinema_Boutique.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CinemaBoutique.Core.Models;
using CinemaBoutique.DAL.EF.Data;
using Microsoft.EntityFrameworkCore;

namespace Cinema_Boutique.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<FilmStrip> FilmStrips;
        protected readonly DbSet<Cinema> Cinemas;
        protected readonly DbSet<FilmSession> FilmSessions;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
            Cinemas = context.Set<Cinema>();
            FilmSessions = context.Set<FilmSession>();
            FilmStrips = context.Set<FilmStrip>();
        }

        public IActionResult Index()
        {
            //Cinema a1 = new Cinema()
            //{
            //    Address = "Lodert street 1", 
            //    ClosingTime = new DateTime(), 
            //    Name = "n1", OpeningTime = new DateTime(), 
            //    PhoneNumber = "929292999299", 
            //    Town = "Minsk",
            //}; 

            Cinema a2 = new Cinema()
            {
                Address = "Lodert street 100",
                ClosingTime = new DateTime(),
                Name = "n100",
                OpeningTime = new DateTime(),
                PhoneNumber = "10000000000000",
                Town = "Minsk",
            };

            //Cinema a3 = new Cinema()
            //{
            //    Address = "Lodert street 3",
            //    ClosingTime = new DateTime(),
            //    Name = "n3",
            //    OpeningTime = new DateTime(),
            //    PhoneNumber = "929292999299",
            //    Town = "Minsk",
            //};

            FilmStrip f1 = new FilmStrip()
            {
                FilmDuration = 10,
                AgeLimit = 18,
                BriefDescription = "short100",
                FullDescription = "Long100",
                ProductionCountry = "Belarus100",
                ReleaseDate = new DateTime(),
                Title = "Title100",
            };

            //FilmStrip f2 = new FilmStrip()
            //{
            //    FilmDuration = 10,
            //    AgeLimit = 18,
            //    BriefDescription = "short",
            //    FullDescription = "Long",
            //    ProductionCountry = "Belarus",
            //    ReleaseDate = new DateTime(),
            //    Title = "Title2"
            //};

            //FilmStrip f3 = new FilmStrip()
            //{
            //    FilmDuration = 10,
            //    AgeLimit = 18,
            //    BriefDescription = "short",
            //    FullDescription = "Long",
            //    ProductionCountry = "Belarus",
            //    ReleaseDate = new DateTime(),
            //    Title = "Title3"
            //};

            //new List<FilmStrip>() { f1 }.ForEach(f => FilmStrips.Add(f));
            FilmStrips.Add(f1);
            _context.SaveChanges();

            new List<Cinema>() { a2 }.ForEach(f => Cinemas.Add(f));
            _context.SaveChanges();

            f1.Cinemas.Add(a2);
            _context.SaveChanges();

            FilmSession session1 = new FilmSession()
            {
                Title = "Title session",
                CinemaId = 7,
                FilmStripId = 7,
                SessionPrice = 10,
                ShowDate = new DateTime().AddDays(+10), 
            };

            //FilmSession session2 = new FilmSession()
            //{
            //    Title = "titile session 2",
            //    CinemaId = 1,
            //    FilmStripId = 1,
            //    SessionPrice = 100,
            //    ShowDate = new DateTime().AddDays(+10),
            //    Id = new Guid()
            //};

            new List<FilmSession>() { session1 }.ForEach(f => FilmSessions.Add(f));
            _context.SaveChanges();


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
