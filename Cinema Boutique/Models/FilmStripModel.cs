using System;
using System.Collections.Generic;
using CinemaBoutique.Core.Enums;
using System.ComponentModel.DataAnnotations;
using CinemaBoutique.Core.Models;

namespace Cinema_Boutique.Models
{
    public class FilmStripModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        public CategoryType Category { get; set; }

        [Required]
        public GenreType Genre { get; set; }

        [Required]
        [Display(Name = "Age limit")]
        public int AgeLimit { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Short info")]
        public string BriefDescription { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Full info")]
        public string FullDescription { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "This field can be contain only letters")]
        [Display(Name = "Country", Prompt = "Belarus")]
        public string ProductionCountry { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Release date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(2, Int32.MaxValue)]
        [Display(Name = "Duration")]
        public int FilmDuration { get; set; }

        public ICollection<ActorModel> Actors { get; set; } = new List<ActorModel>();
        public ICollection<CinemaModel> Cinemas { get; set; } = new List<CinemaModel>();
        public ICollection<FilmSessionModel> FilmSessions { get; set; } = new List<FilmSessionModel>();
    }
}