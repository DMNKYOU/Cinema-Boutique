using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaBoutique.Core.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string Biography { get; set; }

        //многие ко многим свзязь добавить
        public ICollection<FilmStrip> FilmStrips { get; set; } = new List<FilmStrip>();
    }
}
