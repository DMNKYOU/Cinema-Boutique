using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaBoutique.Core.Models;
using CinemaBoutique.DAL.EF.Data;
using Microsoft.EntityFrameworkCore;

namespace CinemaBoutique.DAL.EF.Repositories
{
    public class ActorsRepository : BaseRepository<Actor>
    {

        public ActorsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Task<Actor> GetAsync(int id) 
        {
            return _context.Actors
                .AsNoTracking()
                .Include(s => s.FilmStrips)
                .SingleOrDefaultAsync(sr => sr.Id == id);
        }

        public override Task<List<Actor>> GetAllAsync()
        {
            return _context.Actors
                .AsNoTracking()
                .Include(s => s.FilmStrips)
                .ToListAsync();
        }
    }
}
