using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaBoutique.Core.Models;
using CinemaBoutique.DAL.EF.Data;
using Microsoft.EntityFrameworkCore;

namespace CinemaBoutique.DAL.EF.Repositories
{
    public class FilmSessionsRepository : BaseRepository<FilmSession>
    {

        public FilmSessionsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Task<FilmSession> GetAsync(int id) 
        {
            return _context.FilmSession
                .AsNoTracking()
                .Include(s => s.Cinema)
                .Include(s => s.FilmStrip)
                .Include(sr => sr.Tickets)
                .SingleOrDefaultAsync(sr => sr.Id == id);
        }

        public override Task<List<FilmSession>> GetAllAsync()
        {
            return _context.FilmSession
                .Include(s => s.Cinema)
                .Include(s => s.FilmStrip)
                .OrderBy(s=>s.FilmStripId)
                .Include(sr => sr.Tickets)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
