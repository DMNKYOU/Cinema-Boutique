using System;

namespace CinemaBoutique.Core.Models
{
    public class Class1
    {
        public int Id { get; set; }
        public int CinemaId { get; set; }
        public int FilmStripId { get; set; }
        public string Title { get; set; }
        public int SessionPrice { get; set; }
        public DateTime ShowDate { get; set; } //типа неск записей по ключам фильм кино review
    }
}
