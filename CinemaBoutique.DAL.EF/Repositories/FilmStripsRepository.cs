using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaBoutique.Core.Models;
using CinemaBoutique.DAL.EF.Data;
using Microsoft.EntityFrameworkCore;

namespace CinemaBoutique.DAL.EF.Repositories
{
    public class FilmStripsRepository : BaseRepository<FilmStrip>
    {

        public FilmStripsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Task<FilmStrip> GetAsync(int id) 
        {
            return _context.FilmStrips.AsNoTracking()
                .Include(s => s.FilmSessions)
                .Include(s => s.Cinemas)
                .Include(s => s.Actors)
                .SingleOrDefaultAsync(sr => sr.Id == id);
        }

        public override Task<List<FilmStrip>> GetAllAsync()
        {
            return _context.FilmStrips
                .Include(s => s.FilmSessions)
                .Include(s => s.Cinemas)
                .Include(s => s.Actors)
                .ToListAsync();
        }
    }
}
