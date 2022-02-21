using Cinema_Boutique.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CinemaBoutique.BLL.Interfaces;
using CinemaBoutique.Core.Enums;
using CinemaBoutique.Core.Models;
using CinemaBoutique.DAL.EF.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cinema_Boutique.Controllers
{
    public class TicketsController : Controller
    {

        private readonly ITicketsService _ticketsService;

        private readonly IFilmSessionsService _filmSessionsService;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        private readonly UserManager<User> _userManager;

        public TicketsController(IMapper mapper, ITicketsService ticketsService,
            IFilmSessionsService filmSessionsService,
            ILogger<TicketsController> logger, UserManager<User> userManager)
        {
            _mapper = mapper;
            _logger = logger;
            _ticketsService = ticketsService;
            _filmSessionsService = filmSessionsService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var ticketsAll = await _ticketsService.FindAsync(c => c.UserId == user.Id);
                var resList = _mapper.Map<IEnumerable<Ticket>, List<TicketModel>>(ticketsAll);

                return View(resList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Error", "Error", new { @statusCode = 500 });
            }
        }

        [HttpGet]
        public async Task<IActionResult> BuyTicket(int? filmSessionId, int? idStatusOrder)
        {
            if (!(filmSessionId.HasValue && idStatusOrder.HasValue))
                return RedirectToAction("Index", "FilmSessions");
            
            var user = await _userManager.GetUserAsync(User);

            var session = await _filmSessionsService.GetByIdAsync(filmSessionId.Value);

            var ticket = new Ticket()
            {
                Status = (Status)idStatusOrder,
                FilmSessionId = session.Id,
                SeatNumber = session.AvailableNumberSeats,
                UserId = user.Id
            };

            await _ticketsService.AddAsync(ticket);

            session.AvailableNumberSeats = (session.AvailableNumberSeats - 1) >= 0 ? (--session.AvailableNumberSeats) : 0;
            session.Cinema = null;
            session.FilmStrip = null;

            await _filmSessionsService.EditAsync(session);

            //var resModel = new OrderModel()
            //{
            //    SeatNumber = voyage.NumberSeats,
            //    Status = (Status)idStatusOrder.Value,
            //    VoyageId = voyageId.Value,
            //    Voyage = voyage
            //};
            //return View("Add", resModel);

            return RedirectToAction("Index", "FilmSessions");

            //try
            //{
            //    var user = await _userManager.GetUserAsync(User);
            //    var cinema = await _cinemasService.GetByIdAsync(id);

            //    if (ticket != null && ticket.UserId != user.Id)
            //        return RedirectToAction("Error", "Error", new { @statusCode = 403 });

            //    await _ticketsService.UpdateStatus(ticket);

            //    return RedirectToAction("Index", "Tickets");
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex.ToString());
            //    return RedirectToAction("Error", "Error", new { @statusCode = 500 });
            //}
        }

        [HttpGet]
        public async Task<IActionResult> BuyReservedTicket(int id)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var ticket = await _ticketsService.GetByIdAsync(id);

                if (ticket!= null && ticket.UserId != user.Id)
                    return RedirectToAction("Error", "Error", new { @statusCode = 403 });
                
                await _ticketsService.UpdateStatus(ticket);

                return RedirectToAction("Index", "Tickets");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Error", "Error", new { @statusCode = 500 });
            }
        }
    }
}
