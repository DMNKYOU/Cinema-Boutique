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
    public class CinemasService : ICinemasService
    {
        private readonly IRepositoryAsync<Cinema> _cinemasRepository;

        public CinemasService(IRepositoryAsync<Cinema> cinemasRepository)
        {
            _cinemasRepository = cinemasRepository;
        }

        public async Task<List<Cinema>> GetAllAsync()
        {
            return await _cinemasRepository.GetAllAsync();
        }

        public async Task<Cinema> GetByIdAsync(int id)
        {
            return await _cinemasRepository.GetAsync(id);
        }

        public async Task AddAsync(Cinema entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            await _cinemasRepository.CreateAsync(entity);
        }

        public async Task EditAsync(Cinema entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            await _cinemasRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _cinemasRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Cinema>> FindAsync(Func<Cinema, bool> predicate)
        {
            return await _cinemasRepository.FindAsync(predicate);
        }
    }
}
