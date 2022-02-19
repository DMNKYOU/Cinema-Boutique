using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaBoutique.Core.Models;
using CinemaBoutique.DAL.EF.Data;
using Microsoft.EntityFrameworkCore;

namespace CinemaBoutique.DAL.EF.Repositories
{
    public class TicketsRepository : BaseRepository<Ticket>
    {

        public TicketsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Task<Ticket> GetAsync(int id)
        {
            return _context.Tickets.AsNoTracking()
                .Include(s => s.FilmSession)
                .Include(s => s.User)
                .SingleOrDefaultAsync(sr => sr.Id == id);
        }

        public override Task<List<Ticket>> GetAllAsync()
        {
            return _context.Tickets
                .Include(s => s.FilmSession)
                .Include(s => s.FilmSession.Cinema)
                .Include(s => s.User)
                .ToListAsync();
        }
    }
}
