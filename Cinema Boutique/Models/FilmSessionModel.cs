using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CinemaBoutique.Core.Models;

namespace Cinema_Boutique.Models
{
    public class FilmSessionModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Cinema")]
        public int CinemaId { get; set; }

        public CinemaModel Cinema { get; set; }

        [Required]
        [Display(Name = "Film")]
        public int FilmStripId { get; set; }

        public FilmStripModel FilmStrip { get; set; }

        [Display(Name = "Film name")]
        public string FilmName { get; set; }

        [Required]
        [Range(1, 1000)]
        [Display(Name = "Price")]
        public int SessionPrice { get; set; }
        
        [Required]
        [Range(1, 1000)]
        [Display(Name = "Available")]
        public int AvailableNumberSeats { get; set; }

        [Required]
        [Display(Name = "Show date")]
        public DateTime ShowDate { get; set; }

        public ICollection<TicketModel> Tickets { get; set; } = new List<TicketModel>();
    }
}