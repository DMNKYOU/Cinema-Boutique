using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CinemaBoutique.BLL.Interfaces;
using CinemaBoutique.Core.Models;
using CinemaBoutique.DAL.Interfaces;
using System.Linq;
using CinemaBoutique.Core.Enums;
using Microsoft.Extensions.Logging;

namespace CinemaBoutique.BLL.Services
{
    public class TicketsService : ITicketsService
    {
        private readonly IRepositoryAsync<Ticket> _ticketsRepository;

        public TicketsService(IRepositoryAsync<Ticket> ticketRepository)
        {
            _ticketsRepository= ticketRepository;
        }

        public async Task<List<Ticket>> GetAllAsync()
        {
            return await _ticketsRepository.GetAllAsync();
        }

        public async Task<Ticket> GetByIdAsync(int id)
        {
            return await _ticketsRepository.GetAsync(id);
        }

        public async Task AddAsync(Ticket entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            await _ticketsRepository.CreateAsync(entity);
        }

        public async Task EditAsync(Ticket entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            await _ticketsRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _ticketsRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Ticket>> FindAsync(Func<Ticket, bool> predicate)
        {
            return await _ticketsRepository.FindAsync(predicate);
        }

        public async Task BuyTicketOnSession(Ticket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException();

            ticket.Status = Status.BoughtOut;

            await EditAsync(ticket);
        }

        public async Task UpdateStatus(Ticket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException();

            ticket.Status = Status.BoughtOut;

            await EditAsync(ticket);
        }
    }
}
