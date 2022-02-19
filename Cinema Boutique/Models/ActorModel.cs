using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cinema_Boutique.Validation;

namespace Cinema_Boutique.Models
{
    public class ActorModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "This field can be contain only letters")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "This field can be contain only letters")]
        [Display(Name = "Middle name")]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "This field can be contain only letters")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        [DateInThePast]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Biography", Prompt = "information")]
        public string Biography { get; set; }

        public ICollection<FilmStripModel> FilmStrips { get; set; } = new List<FilmStripModel>();
    }
}