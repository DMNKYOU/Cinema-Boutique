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
    public class FilmStripsService : IFilmStripsService
    {
        private readonly IRepositoryAsync<FilmStrip> _filmStripsRepository;

        public FilmStripsService(IRepositoryAsync<FilmStrip> actorsRepository)
        {
            _filmStripsRepository = actorsRepository;
        }

        public async Task<List<FilmStrip>> GetAllAsync()
        {
            return await _filmStripsRepository.GetAllAsync();
        }

        public async Task<FilmStrip> GetByIdAsync(int id)
        {
            return await _filmStripsRepository.GetAsync(id);
        }

        public async Task AddAsync(FilmStrip entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            await _filmStripsRepository.CreateAsync(entity);
        }

        public async Task EditAsync(FilmStrip entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            await _filmStripsRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _filmStripsRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<FilmStrip>> FindAsync(Func<FilmStrip, bool> predicate)
        {
            return await _filmStripsRepository.FindAsync(predicate);
        }
    }
}
