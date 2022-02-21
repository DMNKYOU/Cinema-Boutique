using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CinemaBoutique.BLL.Interfaces;
using CinemaBoutique.Core.Models;
using CinemaBoutique.DAL.Interfaces;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace CinemaBoutique.BLL.Services
{
    public class FilmSessionsService : IFilmSessionsService
    {
        private readonly IRepositoryAsync<FilmSession> _filmSessionRepository;

        public FilmSessionsService(IRepositoryAsync<FilmSession> actorsRepository)
        {
            _filmSessionRepository = actorsRepository;
        }

        public async Task<List<FilmSession>> GetAllAsync()
        {
            return await _filmSessionRepository.GetAllAsync();
        }

        public async Task<FilmSession> GetByIdAsync(int id)
        {
            return await _filmSessionRepository.GetAsync(id);
        }

        public async Task AddAsync(FilmSession entity)
        {
            if (entity == null || _filmSessionRepository.FindAsync(fs =>
                       fs.CinemaId == entity.CinemaId
                       && fs.FilmStripId == entity.FilmStripId
                       && fs.ShowDate == entity.ShowDate).Result.Any())
                throw new ArgumentException();

            entity.Cinema = null;
            entity.FilmStrip = null;
            entity.AvailableNumberSeats = entity.AvailableNumberSeats >= 0 ? entity.AvailableNumberSeats : 1;

            await _filmSessionRepository.CreateAsync(entity);
        }

        public async Task EditAsync(FilmSession entity)
        {
            var findResult = _filmSessionRepository.FindAsync(fs =>
                fs.CinemaId == entity.CinemaId
                && fs.FilmStripId == entity.FilmStripId
                && fs.ShowDate == entity.ShowDate).Result.ToList();

            if (entity == null || (findResult.Count() == 1 && findResult.First().Id != entity.Id))
                throw new ArgumentException();

            entity.Cinema = null;
            entity.FilmStrip = null;
            entity.AvailableNumberSeats = entity.AvailableNumberSeats >= 0 ? entity.AvailableNumberSeats : 0;

            await _filmSessionRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _filmSessionRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<FilmSession>> FindAsync(Func<FilmSession, bool> predicate)
        {
            return await _filmSessionRepository.FindAsync(predicate);
        }
    }
}
