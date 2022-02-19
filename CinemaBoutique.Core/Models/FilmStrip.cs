using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CinemaBoutique.Core.Enums;

namespace CinemaBoutique.Core.Models
{
    public class FilmStrip
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public CategoryType Category { get; set; }
        public GenreType Genre { get; set; }
        public int AgeLimit { get; set; } 
        public string BriefDescription { get; set; }
        public string FullDescription { get; set; }
        public string ProductionCountry { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public int FilmDuration { get; set; }

        public ICollection<Actor> Actors { get; set; } = new List<Actor>();
        public ICollection<Cinema> Cinemas { get; set; } = new List<Cinema>();
        public ICollection<FilmSession> FilmSessions { get; set; } = new List<FilmSession>();
    }
}
