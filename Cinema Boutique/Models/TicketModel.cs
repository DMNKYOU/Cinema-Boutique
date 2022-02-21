using CinemaBoutique.Core.Enums;
using CinemaBoutique.Core.Models;

namespace Cinema_Boutique.Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public int SeatNumber { get; set; }
        public string FilmSessionId { get; set; }
        public FilmSessionModel FilmSession { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
