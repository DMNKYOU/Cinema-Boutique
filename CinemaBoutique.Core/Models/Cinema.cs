using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaBoutique.Core.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        [DataType(DataType.Time)]
        public DateTime OpeningTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime ClosingTime { get; set; }
        public string PhoneNumber { get; set; }
        public string Town { get; set; }

        public ICollection<FilmStrip> FilmStrips { get; set; } = new List<FilmStrip>();
        public ICollection<FilmSession> FilmSessions { get; set; } = new List<FilmSession>();
    }
}
