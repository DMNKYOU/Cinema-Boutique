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
    public class CinemasController : Controller
    {

        private readonly ICinemasService _cinemasService;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public CinemasController(IMapper mapper, ICinemasService cinemasService,
            ILogger<CinemasController> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _cinemasService = cinemasService;
        }

        [AllowAnonymous]
        // GET: BusStopsController
        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var cinemas = await _cinemasService.GetAllAsync();
                var resList = _mapper.Map<List<Cinema>, List<CinemaModel>>(cinemas);
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
            CinemaModel cinemaModel;
            try
            {
                cinemaModel = id.HasValue
                    ? _mapper.Map<CinemaModel>(await _cinemasService.GetByIdAsync(id.Value))
                    : new CinemaModel();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Error", "Error", new { @statusCode = 500 });
            }

            ViewBag.Action = id.HasValue ? "Edit": "Add";

            return View(cinemaModel);

        }

        // POST: BusStopsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> EditAsync(CinemaModel cinemaModel)
        {

            cinemaModel.Name = cinemaModel.Name.Trim();
            cinemaModel.PhoneNumber = cinemaModel.PhoneNumber.Trim();

            if (!ModelState.IsValid)
                return View("Edit", cinemaModel);

            var cinemas = _mapper.Map<Cinema>(cinemaModel);
            try
            {
                if (cinemas.Id != 0)
                    await _cinemasService.EditAsync(cinemas);
                else
                    await _cinemasService.AddAsync(cinemas);

                return RedirectToAction("Index", "Cinemas");
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
                await _cinemasService.DeleteAsync(id);
                return RedirectToAction("Index", "Cinemas");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Error", "Error", new { @statusCode = 500 });
            }
        }
    }
}
