using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaBoutique.Core.Models;
using CinemaBoutique.DAL.EF.Data;
using Microsoft.EntityFrameworkCore;

namespace CinemaBoutique.DAL.EF.Repositories
{
    public class CinemasRepository : BaseRepository<Cinema>
    {

        public CinemasRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Task<Cinema> GetAsync(int id) 
        {
            return _context.Cinemas.AsNoTracking()
                .Include(s => s.FilmStrips)
                .Include(s => s.FilmSessions)
                .SingleOrDefaultAsync(sr => sr.Id == id);
        }

        public override Task<List<Cinema>> GetAllAsync()
        {
            return _context.Cinemas
                .Include(s => s.FilmStrips)
                .Include(s => s.FilmSessions)
                .ToListAsync();
        }
    }
}
