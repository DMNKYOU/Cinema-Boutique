using System;
using System.Collections.Generic;

namespace CinemaBoutique.Core.Models
{
    public class FilmSession
    {
       public int Id { get; set; }
       public int CinemaId { get; set; } 
       public Cinema Cinema { get; set; } 
       public int FilmStripId { get; set; }
       public FilmStrip FilmStrip { get; set; }
       public int SessionPrice { get; set; } 
       public int AvailableNumberSeats { get; set; } 
       public DateTime ShowDate { get; set; }

       public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
