using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cinema_Boutique.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using CinemaBoutique.BLL.Interfaces;
using CinemaBoutique.Core.Models;

namespace Cinema_Boutique.Controllers
{
    public class FilmSessionsController : Controller
    {

        private readonly IFilmSessionsService _filmSessionsService;
        private readonly ICinemasService _cinemasService;
        private readonly IFilmStripsService _filmStripsService;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public FilmSessionsController(IMapper mapper, 
            IFilmSessionsService filmSessionsService,
            ICinemasService cinemaService,
            IFilmStripsService filmStripsService,
            ILogger<FilmSessionsController> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _filmSessionsService = filmSessionsService;
            _filmStripsService = filmStripsService;
            _cinemasService = cinemaService;
        }

        [AllowAnonymous]
        // GET:  
        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var filmSessions = await _filmSessionsService.GetAllAsync();
                var resList = _mapper.Map<List<FilmSession>, List<FilmSessionModel>>(filmSessions);
                return View(resList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Error", "Error", new { @statusCode = 500 });
            }
        }

        //method used for add and edit
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditAsync(int? id)
        {
            ViewBag.Cinemas = await _cinemasService.GetAllAsync();
            ViewBag.FilmStrips = await _filmStripsService.GetAllAsync();
            FilmSessionModel filmSessionModel;
            try
            {
                filmSessionModel = id.HasValue
                    ? _mapper.Map<FilmSessionModel>(await _filmSessionsService.GetByIdAsync(id.Value))
                    : new FilmSessionModel();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Error", "Error", new { @statusCode = 500 });
            }

            ViewBag.Action = id.HasValue ? "Edit": "Add";

            return View(filmSessionModel);
        }

        // POST:  /Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> EditAsync(FilmSessionModel filmSession)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Cinemas = await _cinemasService.GetAllAsync();
                ViewBag.FilmStrips = await _filmStripsService.GetAllAsync();
                return View("Edit", filmSession);
            }

            var filmSessionMapped = _mapper.Map<FilmSession>(filmSession);

            try
            {
                if (filmSessionMapped.Id != 0)
                    await _filmSessionsService.EditAsync(filmSessionMapped);
                else
                    await _filmSessionsService.AddAsync(filmSessionMapped);

                return RedirectToAction("Index", "FilmSessions");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Error", "Error", new { @statusCode = 500 });
            }
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _filmSessionsService.DeleteAsync(id);
                return RedirectToAction("Index", "FilmSessions");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Error", "Error", new { @statusCode = 500 });
            }
        }
    }
}
