using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaBoutique.Core
{
    public class FilmStrip
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        // public string Categ { get; set; }
        // public enum Жанр { get; set; }
        public string BriefDescription { get; set; }
        public string FullDescription { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }


    }
}
