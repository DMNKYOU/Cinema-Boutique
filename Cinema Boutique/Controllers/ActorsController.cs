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
    public class ActorsController : Controller
    {

        private readonly IActorsService _actorsService;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public ActorsController(IMapper mapper, IActorsService actorsService,
            ILogger<ActorsController> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _actorsService = actorsService;
        }

        [AllowAnonymous]
        // GET: BusStopsController
        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var actors = await _actorsService.GetAllAsync();
                var resList = _mapper.Map<List<Actor>, List<ActorModel>>(actors);
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
            ActorModel cinemaModel;
            try
            {
                cinemaModel = id.HasValue
                    ? _mapper.Map<ActorModel>(await _actorsService.GetByIdAsync(id.Value))
                    : new ActorModel();
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
        public async Task<ActionResult> EditAsync(ActorModel cinemaModel)
        {

            cinemaModel.FirstName = cinemaModel.FirstName.Trim();
            cinemaModel.LastName = cinemaModel.LastName.Trim();

            if (!ModelState.IsValid)
                return View("Edit", cinemaModel);

            var actors = _mapper.Map<Actor>(cinemaModel);
            try
            {
                if (actors.Id != 0)
                    await _actorsService.EditAsync(actors);
                else
                    await _actorsService.AddAsync(actors);

                return RedirectToAction("Index", "Actors");
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
                await _actorsService.DeleteAsync(id);
                return RedirectToAction("Index", "Actors");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Error", "Error", new { @statusCode = 500 });
            }
        }
    }
}
