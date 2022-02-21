using CinemaBoutique.Core.Enums;

namespace CinemaBoutique.Core.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public int SeatNumber { get; set; }
        public int FilmSessionId { get; set; }
        public FilmSession FilmSession { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
