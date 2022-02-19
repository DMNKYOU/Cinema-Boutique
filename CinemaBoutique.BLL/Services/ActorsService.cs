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
    public class ActorsService : IActorsService
    {
        private readonly IRepositoryAsync<Actor> _actorsRepository;

        public ActorsService(IRepositoryAsync<Actor> actorsRepository)
        {
            _actorsRepository = actorsRepository;
        }

        public async Task<List<Actor>> GetAllAsync()
        {
            return await _actorsRepository.GetAllAsync();
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            return await _actorsRepository.GetAsync(id);
        }

        public async Task AddAsync(Actor entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            await _actorsRepository.CreateAsync(entity);
        }

        public async Task EditAsync(Actor entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            await _actorsRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _actorsRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Actor>> FindAsync(Func<Actor, bool> predicate)
        {
            return await _actorsRepository.FindAsync(predicate);
        }
    }
}
