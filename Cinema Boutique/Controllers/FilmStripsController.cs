using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cinema_Boutique.Models;
using CinemaBoutique.BLL.Interfaces;
using CinemaBoutique.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace Cinema_Boutique.Controllers
{
    public class FilmStripsController : Controller
    {

        private readonly IFilmStripsService _filmStripsService;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public FilmStripsController(IMapper mapper, IFilmStripsService filmStripsService,
            ILogger<IFilmStripsService> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _filmStripsService = filmStripsService;
        }

        [AllowAnonymous]
        // GET: BusStopsController
        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var filmStrips = await _filmStripsService.GetAllAsync();
                var resList = _mapper.Map<List<FilmStrip>, List<FilmStripModel>>(filmStrips);
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
            FilmStripModel filmStripModel;
            try
            {
                filmStripModel = id.HasValue
                    ? _mapper.Map<FilmStripModel>(await _filmStripsService.GetByIdAsync(id.Value))
                    : new FilmStripModel();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Error", "Error", new { @statusCode = 500 });
            }

            ViewBag.Action = id.HasValue ? "Edit": "Add";

            return View(filmStripModel);

        }

        // POST: BusStopsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> EditAsync(FilmStripModel filmStripModel)
        {

            filmStripModel.BriefDescription = filmStripModel.BriefDescription.Trim();
            filmStripModel.FullDescription = filmStripModel.FullDescription.Trim();

            if (!ModelState.IsValid)
                return View("Edit", filmStripModel);

            var filmStrips = _mapper.Map<FilmStrip>(filmStripModel);
            try
            {
                if (filmStrips.Id != 0)
                    await _filmStripsService.EditAsync(filmStrips);
                else
                    await _filmStripsService.AddAsync(filmStrips);

                return RedirectToAction("Index", "FilmStrips");
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
                await _filmStripsService.DeleteAsync(id);
                return RedirectToAction("Index", "FilmStrips");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Error", "Error", new { @statusCode = 500 });
            }
        }
    }
}
