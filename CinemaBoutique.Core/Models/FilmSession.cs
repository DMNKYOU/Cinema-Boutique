using System;

namespace CinemaBoutique.Core.Models
{
    public class FilmSession
    {
       // public Guid Id { get; set; }
        public int CinemaId { get; set; } 
        public Cinema Cinema { get; set; }
        public int FilmStripId { get; set; }
        public FilmStrip FilmStrip { get; set; }
        public string Title { get; set; }
        public int SessionPrice { get; set; }
        public DateTime ShowDate { get; set; } //типа неск записей по ключам фильм кино review
    }
}
