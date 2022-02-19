using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinema_Boutique.Models
{
    public class CinemaModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "This field can be contain only letters")]
        [Display(Name = "Name", Prompt = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 2)]
        [Display(Name = "Address", Prompt = "Address")]
        public string Address { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [Display(Name = "Opening Hour")]
        public DateTime OpeningTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [Display(Name = "Closing Hour")]
        public DateTime ClosingTime { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 2)]
        [RegularExpression(@"^(\+?375|[0])(17|29|33|44)[0-9]{7}$", ErrorMessage = "This field can be contain only numbers")]
        [Display(Name = "Phone number", Prompt = "+375295551122")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "This field can be contain only letters")]
        [Display(Name = "City", Prompt = "city name")]
        public string Town { get; set; }

        public ICollection<FilmStripModel> FilmStrips { get; set; } = new List<FilmStripModel>();
        public ICollection<FilmSessionModel> FilmSessions { get; set; } = new List<FilmSessionModel>();
    }
}
